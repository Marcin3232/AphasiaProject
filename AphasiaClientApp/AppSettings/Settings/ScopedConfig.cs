using AphasiaClientApp.Extensions;
using AphasiaClientApp.Extensions.RequestMethod;
using AphasiaClientApp.Services.ExerciseResultHistoryServices;
using AphasiaClientApp.Utils.Js.Sounds;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Storages;

namespace AphasiaClientApp.AppSettings.Settings;

public static class ScopedConfig
{
    public static void Config(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddScoped<IRequestMethod, RequestMethod>();
        builder.Services.AddScoped<ISnackbarMessage, SnackbarMessage>();
        builder.Services.AddScoped<ISoundService, SoundService>();
        builder.Services.AddScoped<IExerciseResultHistoryService, ExerciseResultHistoryService>();
        builder.AddStorageService();
    }
}
