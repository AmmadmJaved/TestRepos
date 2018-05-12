using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models.AccountViewModels;
using WebApp.Services;
using WebSecurity;

namespace WebApp.Controllers.api
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly ISecurityService _securityService;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger,
            ISecurityService securityService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _securityService = securityService;
        }
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model, string returnUrl = null)
        {
            try
            {
                var result = await _securityService.LoginAsync(model.Email, model.Password, false);

                return new ObjectResult(result);


                //return new BadRequestObjectResult("Signup failed. Please try again.");


            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Something went wrong , please try again.");
            }
        }
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model, string returnUrl = null)
        {
            try
            {
                var result = await _securityService.Register(model.Email, model.Email, model.Password, model.ConfirmPassword);
                if (result.Status == LoginStatus.Succeded)
                {
                    var loginModel = new LoginViewModel
                    {
                        Email = model.Email,
                        Password = model.Password,
                        RememberMe = true
                    };

                    return await Login(loginModel);

                }

                return new ObjectResult(result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Something went wrong , please try again.");
            }

        }
    }
}