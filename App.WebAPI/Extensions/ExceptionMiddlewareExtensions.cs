using log4net.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace App.WebAPI.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        private static readonly log4net.ILog s_logger = log4net.LogManager.GetLogger(typeof(ExceptionMiddlewareExtensions));

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        s_logger.Error($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync("Internal Server Error.");                        
                    }
                });
            });
        }

    }
}
