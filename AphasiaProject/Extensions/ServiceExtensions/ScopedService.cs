using AphasiaProject.Services.Dapper;
using AphasiaProject.Services.Exercise;
using DataBaseProject.Context;
using ExerciseResource.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace AphasiaProject.Extensions.ServiceExtensions
{
    public static class ScopedService
    {
        public static void ScopedServiceConfig(this IServiceCollection service)
        {
            service.AddScoped<IDbContext,DbContext>();
            service.AddScoped<IDbRepository,DbRepository>();
            service.AddScoped<IExerciseDbContext,ExerciseDbContext>();
            service.AddScoped<IExerciseResourcesFactory,ExerciseResourcesFactory>();
            service.AddScoped<IExerciseService,ExerciseService>();
        }
    }
}
