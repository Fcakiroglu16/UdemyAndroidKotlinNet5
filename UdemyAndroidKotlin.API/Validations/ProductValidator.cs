using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAndroidKotlin.API.Models;

namespace UdemyAndroidKotlin.API.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün ismi gereklidir.");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("stok alanı gereklidir.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fıyatı gereklidir.");
            RuleFor(x => x.Color).NotEmpty().WithMessage("Ürün rengi gereklidir.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün ismi gereklidir.");
        }
    }
}