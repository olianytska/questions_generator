using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;

namespace PL.Extensions
{
    public static class ExeptionMiddlewareExeption
    {
        public static void ConfigureBuildInExeptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var _logger = loggerFactory.CreateLogger("exeptionhandlermiddleware");
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var contextRequest = context.Features.Get<IHttpRequestFeature>();

                    if (contextFeature != null)
                    {
                        string _error = $"[{context.Response.StatusCode}] - {contextFeature.Error.Message}: {contextRequest.Path}";

                        _logger.LogError(_error);

                        await context.Response.WriteAsync(_error);
                    }
                });
            });
        }
    }
}
