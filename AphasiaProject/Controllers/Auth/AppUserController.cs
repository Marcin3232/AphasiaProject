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
using AphasiaProject.Utils;
using IdentityServer4.Services;
using LoggerService.Manager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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

        public AppUserController(UserManager<AppUser> appUserManager, SignInManager<AppUser> signInManager, ILoggerManager<AppUserController> logger,
            IOptions<AppSettings> appSettings)
        {
            UserManager = appUserManager;
            SignInManager = signInManager;
            _logger = logger;
            AppSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> UserRegister([FromForm] AppRegisterRequestViewModel model)
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
                    Surname = model.Surname,
                    FirstName = model.FirstName,
                    CreateDateTime = DateTime.Now,
                    IsActive = false
                };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    _logger.LogError($"BadRequest message: {result.Errors}");
                    return BadRequest(result.Errors);
                }

                await UserManager.AddClaimAsync(user, new Claim("UserName", user.UserName));
                await UserManager.AddClaimAsync(user, new Claim("FirstName", user.FirstName));
                await UserManager.AddClaimAsync(user, new Claim("Surname", user.Surname));
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
        public async Task<IActionResult> Login(AppLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Bad validation data");
                return BadRequest(ModelState);
            }
               var user = await UserManager.FindByNameAsync(model.UserName);

                if (user != null && await UserManager.CheckPasswordAsync(user, model.Password))
                {
                    var tokenDesc = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("UserId", user.Id.ToString()),
                            new Claim("Email",user.Email),
                            new Claim("UserName",user.UserName)
                        }),
                        Expires = DateTime.UtcNow.AddMonths(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDesc);
                    var token = tokenHandler.WriteToken(securityToken);

                    _logger.LogInfo($"User {user.Id} to logged in {DateTime.Now}");
                    return Ok(new { token });
                }

                _logger.LogInfo(($"Login failed {model.UserName}"));
                return BadRequest();
        }

        [HttpGet]
        [Route("test")]
        public async Task Test()
        {
            var e = ExerciseNameFillList.ExerciseNameList();
        }
    }
}
