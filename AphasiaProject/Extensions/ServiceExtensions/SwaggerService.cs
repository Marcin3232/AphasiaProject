using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AphasiaProject.Extensions.ServiceExtensions
{
    public static class SwaggerService
    {
        public static void SwaggerServiceConfig(this IServiceCollection services) => services.AddSwaggerGen();

        public static void SwaggerConfigure(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
