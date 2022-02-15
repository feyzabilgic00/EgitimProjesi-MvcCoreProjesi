using CoreApp102.Api.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CoreApp102.Api.Extensions
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;
                        if (ex != null)
                        {
                            ErrorDto errorDto = new ErrorDto();
                            errorDto.Status = 500;
                            errorDto.Errors.Add(ex.Message);
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                        }
                    }
                });
            });
        }
    }
}
