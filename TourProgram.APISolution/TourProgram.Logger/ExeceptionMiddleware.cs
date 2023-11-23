using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

namespace TourProgram.Logger
{
    public class ExeceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExeceptionMiddleware> _logger;
        // private readonly IHostEnvironment _env;
        private readonly IHostingEnvironment _env;

        public ExeceptionMiddleware(RequestDelegate next, ILogger<ExeceptionMiddleware> logger, IHostingEnvironment env)
        {
            _env = env;
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                    ? new AppExecption(context.Response.StatusCode, ex.Message, ex.InnerException?.ToString())
                    : new AppExecption(context.Response.StatusCode, ex.Message, ex.InnerException?.ToString());

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
