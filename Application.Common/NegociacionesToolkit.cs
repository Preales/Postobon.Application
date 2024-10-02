using Application.Common.Application.Midleware;
using Application.Common.Utility;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common
{
    public static class NegociacionesToolkit
    {
        public static IServiceCollection AddMNegociacionesToolkit(this IServiceCollection services)
        {
            services.AddScoped<ISystem, SystemExtension>();
            return services;
        }

        //#warning METER ESTE METODO EN DONDE SE TIENE LA IDENTIDAD DEL USUARIO YA DEFINIDA
        //private async Task SetPrincipalOnCache(Guid id, string token, Guid tenantId, string cognito_idToken = null, string cognito_accessToken = null)
        //{
        //    var user = await _unitOfWork.User.GetAsync(x => x.Id == id);
        //    if (user != null)
        //    {
        //        var roles = await _roleModule.GetRolesAsync(user.Id);
        //        if (roles != null && roles.Count > 0)
        //        {
        //            var permissions = _permissionModule.ListByUser(user.Id);
        //            _system.Set(user, roles, tenantId, permissions?.Select(x => x.Name).ToList(), cognito_idToken, cognito_accessToken);
        //            if (_system.TenantId != Guid.Empty)
        //                _cache.Set<SystemExtension>(CacheKey<SystemExtension>.Create(user.Id), _system as SystemExtension);
        //        }
        //    }
        //}

    }
}
