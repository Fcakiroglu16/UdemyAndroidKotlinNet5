using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAndroidKotlin.Auth.Models;

namespace UdemyAndroidKotlin.Auth.Validation
{
    public class SignUpViewModelValidator : AbstractValidator<SignUpViewModel>
    {
        public SignUpViewModelValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı gereklidir");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı gereklidir").EmailAddress().WithMessage("Email adresi doğru formatta değil");
            RuleFor(x => x.Password).NotEmpty().WithMessage("şifre alanı gereklidir");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı gereklidir");
        }
    }
}