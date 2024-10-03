using Microsoft.AspNetCore.Http;

namespace Application.Common.Application.Midleware
{
    public sealed class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(
            RequestDelegate next
            )
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context, ISystem system)
        {
            system.Set(new UserInfo("system"), default!);
            await _next(context);
        }
    }
}
