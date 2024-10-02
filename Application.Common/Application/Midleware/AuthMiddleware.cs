using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Application.Midleware
{
    public sealed class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _factory;

        public AuthMiddleware(
            RequestDelegate next,
            IServiceScopeFactory factory
            )
        {
            _next = next;
            _factory = factory;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            // Lógica del middleware aquí
            using (var scope = _factory.CreateScope())
            {
                var systemService = scope.ServiceProvider.GetRequiredService<ISystem>();
                systemService.Set(new UserInfo("system"), default!);
            }
            await _next(context);
        }
    }
}
