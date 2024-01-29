using BibliotecaDaSetimaArte.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.NetworkInformation;

namespace BibliotecaDaSetimaArte.Extensions
{
    public static class ApiExceptionMiddlewareExceptions
    {
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
                        await context.Response.WriteAsync(new ErrorModel()
                        {
                            ErrorCode = context.Response.StatusCode,
                            ErrorMessage = contextFeature.Error.Message,
                            Trance = contextFeature.Error.StackTrace

                        }.ToString());

                    };
                });
            });
        }
    }
}
