using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UdemyAndroidKotlin.Shared.Extentions
{
    public static class UseDevelopmentDelayMiddleware
    {
        public static void UseDelayRequestDevelopment(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
           {
               await Task.Delay(4000);

               await next.Invoke();
           });
        }
    }
}