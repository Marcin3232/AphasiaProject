using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AphasiaProject.Models.Auth;
using AphasiaProject.Models.Users;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using ILogger = NLog.ILogger;

namespace AphasiaProject.Controllers.Auth
{
    [Route("api/userControllers")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly ILogger<AppUserController> Logger;
        private UserManager<AppUser> UserManager;
        private SignInManager<AppUser> SignInManager;

        public AppUserController(UserManager<AppUser> appUserManager, SignInManager<AppUser> signInManager, ILogger<AppUserController> logger)
        {
            UserManager = appUserManager;
            SignInManager = signInManager;
            Logger = logger;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> UserRegister([FromForm]AppRegisterRequestViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new AppUser()
            {
                UserName = model.Login,
                Email = model.Email,
                Surname = model.Surname,
                FirstName = model.FirstName,
                CreateDateTime = DateTime.Now,
                IsActive = false
            };
            var result = await UserManager.CreateAsync(user,model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await UserManager.AddClaimAsync(user, new Claim("UserName", user.UserName));
            await UserManager.AddClaimAsync(user, new Claim("FirstName", user.FirstName));
            await UserManager.AddClaimAsync(user, new Claim("Surname", user.Surname));
            await UserManager.AddClaimAsync(user, new Claim("Email", user.Email));
            await UserManager.AddClaimAsync(user, new Claim("Role", "Admin"));

            Logger.LogInformation($"Add new user id: {user.Id}");
            return Ok(new AppRegisterResponseViewModel(user));
        }
    }
}
