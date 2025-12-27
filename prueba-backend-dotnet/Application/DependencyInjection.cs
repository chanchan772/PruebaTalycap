using Microsoft.Extensions.DependencyInjection;
using TalycapGlobalNet.Application;

namespace TalycapGlobalNet.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();

            return services;
        }
    }
}
