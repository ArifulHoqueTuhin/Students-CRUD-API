using System.Diagnostics;

namespace CRUDAPI.CustomMiddleware
{
    public class RequestLogingCustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLogingCustomMiddleware> _logger;

        public RequestLogingCustomMiddleware(RequestDelegate next, ILogger<RequestLogingCustomMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path;
            var method = context.Request.Method;
            var timestamp = DateTime.UtcNow;


            // Only log if the path contains 'user'
            if (path.HasValue && path.Value.ToLower().Contains("user"))
            {
                //Debug.WriteLine($"[LOG] {timestamp} - {method} {path}");
                _logger.LogInformation($"[LOG] {timestamp} - {method} {path}");
            }

            await _next(context);

        }
    }
}
