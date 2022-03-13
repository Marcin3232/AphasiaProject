using AphasiaProject.Models.DB;
using DataBaseProject.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AphasiaProject.Extensions.ServiceExtensions
{
    public static class PostgreSqlService
    {

        public static void PostgreSqlServiceConfig(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureSqlContext(services, configuration);
            ConfigureSqlExerciseContext(services, configuration);
        }

        private static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        private static void ConfigureSqlExerciseContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ExerciseDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
}
