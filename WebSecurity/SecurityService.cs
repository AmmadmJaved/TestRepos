using Data;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebSecurity
{
     public interface ISecurityService
    {
        Task<LoginResponse> LoginAsync(string Email, string Password, bool RememberMe, bool persistCookie = false);
        Task<LoginResponse> Register(string name, string email, string password, string confirmpassword);

    }
    public class SecurityService: ISecurityService
    {
        private readonly UserManager<ApplicationUser> _userManager; // re4adOnly Must be assing value in 
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly string ISAuthority = "http://localhost:5000/";
        public SecurityService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;


        }
        public async Task<LoginResponse> LoginAsync(string Email, string Password, bool RememberMe, bool persistCookie = false)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            //var result = await _signInManager(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (user.EmailConfirmed)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, Password, false);
                if (result.Succeeded)
                {


                    var disco = await DiscoveryClient.GetAsync("http://localhost:5000");
                    if (disco.IsError)
                    {
                        return new LoginResponse { Status = LoginStatus.Failed, Message = disco.Error };

                    }

                    //request token
                    var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret");
                    //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                   var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(user.Email, Password, "api1");

                    if (tokenResponse.IsError)
                    {
                        return new LoginResponse { Status = LoginStatus.Failed, Message = tokenResponse.Error };
                    }

                    ////Console.WriteLine(tokenResponse.Json);
                    return new LoginResponse { Status = LoginStatus.Failed, Data = tokenResponse.Json };



                }
                return new LoginResponse { Status = LoginStatus.Failed, Message = "failed" };
            }
            return new LoginResponse { Status = LoginStatus.Failed, Message = "failed" };
        }

        public async Task<LoginResponse> Register(string name, string email, string password, string confirmpassword) {

            var user = new ApplicationUser { UserName = name, Email = email, EmailConfirmed = true };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {

                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                await _signInManager.SignInAsync(user, isPersistent: false);
                return new LoginResponse { Status = LoginStatus.Succeded, Data = user };
            }

            return new LoginResponse { Status = LoginStatus.Failed, Data = null };
        }
    }
}
