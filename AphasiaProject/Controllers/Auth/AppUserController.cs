using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AphasiaProject.Models.Auth;
using AphasiaProject.Models.Users;
using IdentityServer4.Services;
using LoggerService.Manager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using CommonExercise.Models.User;
using AphasiaProject.Services.User;

namespace AphasiaProject.Controllers.Auth
{
    [Route("api/userControllers")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly ILoggerManager<AppUserController> _logger;
        private readonly UserManager<AppUser> UserManager;
        private readonly SignInManager<AppUser> SignInManager;
        private readonly AppSettings AppSettings;

        private readonly IIdentityServerInteractionService ServerInteraction;

        private readonly IUserActionService _userActionService;

        public AppUserController(UserManager<AppUser> appUserManager, SignInManager<AppUser> signInManager, ILoggerManager<AppUserController> logger,
            IOptions<AppSettings> appSettings, IUserActionService userActionService)
        {
            UserManager = appUserManager;
            SignInManager = signInManager;
            _logger = logger;
            AppSettings = appSettings.Value;
            _userActionService = userActionService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> UserRegister(AppRegisterRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Bad validation data");
                return BadRequest(ModelState);
            }

            try
            {
                var user = new AppUser()
                {
                    UserName = model.Login,
                    Email = model.Email,
                    Role = model.Role,
                    CreateDateTime = DateTime.UtcNow,
                    IsActive = false
                };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    _logger.LogError($"BadRequest message: {result.Errors}");
                    return BadRequest(result.Errors);
                }

                await UserManager.AddClaimAsync(user, new Claim("Role", user.Role));
                await UserManager.AddClaimAsync(user, new Claim("UserName", user.UserName));
                await UserManager.AddClaimAsync(user, new Claim("Email", user.Email));
                await UserManager.AddClaimAsync(user, new Claim("Role", "Admin"));

                _logger.LogInfo($"Add new user id: {user.Id}");
                return Ok(new AppRegisterResponseViewModel(user));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(AppUserController)}. Exception: {ex}");
                return StatusCode(500, "Inside server problem");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout(int id)
        {
            await SignInManager.SignOutAsync();
            var context = await ServerInteraction.GetLogoutContextAsync(id.ToString());
            return Redirect(context.PostLogoutRedirectUri);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(AppLoginViewModel model)        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Bad validation data");
                return BadRequest(ModelState);
            }
            var user = await UserManager.FindByNameAsync(model.UserName);

            if (user != null && await UserManager.CheckPasswordAsync(user, model.Password))
            {

                var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.JWT_Secret))
                    , SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>()
                {
                    new Claim("Id",user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.Email),
                    new Claim(ClaimTypes.Role,user.Role),
                };
                var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { token });
            }

            _logger.LogInfo(($"Login failed {model.UserName}"));
            return BadRequest();
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials);
            return tokenOptions;
        }




        [HttpGet("edit/personalData/{userid}")]
        [Produces("application/json")]
        public async Task<ActionResult> GETEditPersonalData(int userid)
        {
            try
            {
                var result = _userActionService.GetUserData(userid);
                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Problem(ex.ToString());
            }
        }

        [HttpPost("edit/personalData/{userid}")]
        [Produces("application/json")]
        public async Task<ActionResult> POSTEditPersonalData(int userid, UserPersonalDetailModel model)
        {
            model.Id = Convert.ToInt32(userid);
            try
            {
                var result = _userActionService.UpdateUserPersonalData(model);
                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Problem(ex.ToString());
            }
        }

        [HttpPost("edit/password/{userid}")]
        [Produces("application/json")]
        public async Task<ActionResult> POSTEditPassword(int userid, PasswordModel model)
        {
           model.Id = userid;
           var user = await UserManager.FindByIdAsync(userid.ToString());
           await UserManager.ChangePasswordAsync(user, model.PassOld, model.PassNew);
           return (Ok("ok"));
        }

        [HttpPost("create/patient")]
        [Produces("application/json")]
        public async Task<ActionResult> POSTCreatePatient(PatientCreationModel model)
        {

            var user = new AppUser()
            {
                UserName = model.Login,
                Role = "Patient",
                Email = "DefaultEmail@org.com",
                CreateDateTime = DateTime.UtcNow,
                IsActive = false,
                TherapistId = model.Id
            };
            await UserManager.CreateAsync(user, model.Password);

            await UserManager.AddClaimAsync(user, new Claim("Role", user.Role));
            await UserManager.AddClaimAsync(user, new Claim("UserName", user.UserName));
            await UserManager.AddClaimAsync(user, new Claim("Email", user.Email));


            _logger.LogInfo($"Add new user id: {user.Id}");

          

            await _userActionService.createUserExcercises(user.Id);

            return Ok(new AppRegisterResponseViewModel(user));
        }

        [HttpGet("patients/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult> GETPatients(int id)
        {
            try
            {
                var result = _userActionService.GetPatients(id);
                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Problem(ex.ToString());
            }
        }


        [HttpGet("patients/getExercises/{id}/{type}")]
        [Produces("application/json")]
        public async Task<ActionResult> GetPatientExercises(int id,int type)
        {
            try
            {
                var result = _userActionService.GetPacientsExercises(id,type);
                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Problem(ex.ToString());
            }
        }

    }



    //public class PersonalDetailsModel
    //{
    //    [JsonPropertyName("city")]
    //    public string City { get; set; }

    //    [JsonPropertyName("email")]
    //    public string Email { get; set; }

    //    [JsonPropertyName("houseNbr")]
    //    public int HouseNbr { get; set; }

    //    [JsonPropertyName("phoneNumber")]
    //    public int PhoneNumberd { get; set; }

    //    [JsonPropertyName("postalCode")]
    //    public string PostalCode { get; set; }

    //    [JsonPropertyName("street")]
    //    public string Street { get; set; }
    //}
}
