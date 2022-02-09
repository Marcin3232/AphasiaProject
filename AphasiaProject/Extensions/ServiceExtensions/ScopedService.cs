using AphasiaProject.Services.Dapper;
using Microsoft.Extensions.DependencyInjection;

namespace AphasiaProject.Extensions.ServiceExtensions
{
    public static class ScopedService
    {
        public static void ScopedServiceConfig(this IServiceCollection service)
        {
            service.AddScoped<IDbContext,DbContext>();
            service.AddScoped<IDbRepository,DbRepository>();
        }
    }
}
