using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AphasiaProject.Extensions.ServiceExtensions
{
    public static class CorsService
    {
        public static void ConfigureCors(this IServiceCollection services) => services.AddCors(option => option.AddPolicy(
             "APIPolicy", builder =>
             {
                 builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
             }));

        public static void CorsCofigure(this IApplicationBuilder app) => app.UseCors("APIPolicy");
    }
}
