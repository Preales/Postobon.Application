using Application.Common.Utility;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Application.Midleware
{
    public sealed class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ISystem _system;

        public AuthMiddleware(
            RequestDelegate next,
            ISystem system
            )
        {
            _next = next;
            _system = system;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            // Lógica del middleware aquí
            _system.Set(new UserInfo("system"), default!);
            await _next(context);
        }
    }
}
