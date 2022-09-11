using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace NZWalksApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(
             option =>
             {
                 option.Run(async context =>
                 {
                     context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                     var ex = context.Features.Get<IExceptionHandlerFeature>();
                     if (ex != null)
                     {
                         await context.Response.WriteAsync(ex.Error.Message);
                     }
                 });
             });
        }
    }
}
