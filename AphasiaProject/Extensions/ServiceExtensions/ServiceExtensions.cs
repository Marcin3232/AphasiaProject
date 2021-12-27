using LoggerService.ConfigureService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AphasiaProject.Extensions.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void SetConfigureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.PostgreSqlServiceConfig(configuration);
            services.ConfigureCors();
            services.AuthenticationServiceConfig(configuration);
            services.AddControllers();
            services.SwaggerServiceConfig();
            services.ConfigureLoggerService();

            // do usuniecia pozniej
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        public static void SetConfigure(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseCors("APIPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public static void SetDevelopmentConfigure(this IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.SwaggerConfigure();
        }
    }
}
