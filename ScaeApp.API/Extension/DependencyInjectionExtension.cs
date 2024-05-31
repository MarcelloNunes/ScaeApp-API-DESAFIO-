using ScaeApp.Domain.Interface.Repositories;
using ScaeApp.Domain.Interface.Services;
using ScaeApp.Domain.Services;
using ScaeApp.Infra.Data.Repositories;

namespace ScaeApp.API.Extension
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {

            services.AddScoped<IClienteDomainService, ClienteDomainService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            return services;
        }

    }
}
