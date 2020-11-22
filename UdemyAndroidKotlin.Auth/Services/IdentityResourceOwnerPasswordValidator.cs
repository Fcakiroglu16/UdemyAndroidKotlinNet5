using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAndroidKotlin.Auth.Models;

namespace UdemyAndroidKotlin.Auth.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var existUser = await _userManager.FindByEmailAsync(context.UserName);

            //ErrorDto dönülecek
            if (existUser == null)
            {
                var errors = new Dictionary<string, object>();

                errors.Add("errors", new List<string> { "Email veya şifreniz yanlış" });
                errors.Add("status", 400);
                errors.Add("isShow", true);

                context.Result.CustomResponse = errors;
                return;
            }

            var passwordCheck = await _userManager.CheckPasswordAsync(existUser, context.Password);

            //ErrorDto dönülecek
            if (passwordCheck == false)
            {
                var errors = new Dictionary<string, object>();

                errors.Add("errors", new List<string> { "Email veya şifreniz yanlış" });
                errors.Add("status", 400);
                errors.Add("isShow", true);

                context.Result.CustomResponse = errors;
                return;
            }

            context.Result = new GrantValidationResult(existUser.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
        }
    }
}