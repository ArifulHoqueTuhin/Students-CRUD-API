//using CRUDAPI.Models;
//using Microsoft.EntityFrameworkCore;

//namespace CRUDAPI.CustomMiddleware
//{
//    public class AuthenticationCustomMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly IServiceProvider _serviceProvider; // IServiceProvider to resolve DbContext

//        public AuthenticationCustomMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
//        {
//            _next = next;
//            _serviceProvider = serviceProvider;
//        }

//        public async Task InvokeAsync(HttpContext context)
//        {



//            if (context.Request.Path.StartsWithSegments("/swagger"))
//            {
//                await _next(context);
//                return;
//            }

//            using (var scope = _serviceProvider.CreateScope())
//            {
//                var dbContext = scope.ServiceProvider.GetRequiredService<CodeFirstApproach2Context>();

//                var userEmail = context.Request.Headers["Email"].FirstOrDefault();
//                var userPassword = context.Request.Headers["Password"].FirstOrDefault();

//                if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(userPassword))
//                {
//                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
//                    await context.Response.WriteAsync("Unauthorized: Missing user credentials.");
//                    return;
//                }

//                // Check if the user exists in the database
//                var user = await dbContext.Users
//                    .Where(x => x.Email == userEmail && x.Password == userPassword)
//                    .FirstOrDefaultAsync();

//                if (user == null)
//                {
//                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
//                    await context.Response.WriteAsync("Unauthorized: Invalid credentials.");
//                    return;
//                }

//                await _next(context); // Call the next middleware in the pipeline
//            }
//        }
//    }


//}
