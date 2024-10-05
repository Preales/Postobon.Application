using Application.Common.Application.Midleware;
using Application.Common.Domain.Interfaces;
using Application.Common.Domain.Services;
using Application.Common.Infraestructure.DataAccess;
using Application.Common.Infraestructure.IRepositories;
using Application.Common.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common
{
    public static class DependecyInjectionNegotiations
    {
        public static IServiceCollection AddNegotiationModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddMemoryCache();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddServices();
            return services;
        }


        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISystem, SystemExtension>();
            services.AddRepositories();
            services.AddService();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IMacrosegmentRepository, MacrosegmentRepository>();
            services.AddScoped<ITypologyRepository, TypologyRepository>();
            services.AddScoped<ExceptionModule>();
            return services;
        }

        private static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IMacrosegmentService, MacrosegmentService>();
            services.AddScoped<ITypologyService, TypologyService>();
            return services;
        }


        ///#warning METER ESTE METODO EN DONDE SE TIENE LA IDENTIDAD DEL USUARIO YA DEFINIDA
        ///private async Task SetPrincipalOnCache(Guid id, string token, Guid tenantId, string cognito_idToken = null, string cognito_accessToken = null)
        ///{
        ///    var user = await _unitOfWork.User.GetAsync(x => x.Id == id);
        ///    if (user != null)
        ///    {
        ///        var roles = await _roleModule.GetRolesAsync(user.Id);
        ///        if (roles != null && roles.Count > 0)
        ///        {
        ///            var permissions = _permissionModule.ListByUser(user.Id);
        ///            _system.Set(user, roles, tenantId, permissions?.Select(x => x.Name).ToList(), cognito_idToken, cognito_accessToken);
        ///            if (_system.TenantId != Guid.Empty)
        ///                _cache.Set<SystemExtension>(CacheKey<SystemExtension>.Create(user.Id), _system as SystemExtension);
        ///        }
        ///    }
        ///}

    }
}
