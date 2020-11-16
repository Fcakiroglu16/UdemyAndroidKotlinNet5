using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UdemyAndroidKotlin.Shared.Models;

namespace UdemyAndroidKotlin.Shared.Extentions
{
    public static class UseCustomValidationResponseHandler
    {
        public static void UseCustomValidationResponse(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                 {
                     var errors = context.ModelState.Values.Where(x => x.Errors.Count > 0).SelectMany(x => x.Errors).Select(x => x.ErrorMessage);

                     ErrorDto errorDto = new ErrorDto();

                     errorDto.Errors.AddRange(errors);

                     errorDto.Status = 400;
                     errorDto.IsShow = true;

                     return new BadRequestObjectResult(errorDto);
                 };
            });
        }
    }
}