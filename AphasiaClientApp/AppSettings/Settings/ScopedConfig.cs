using AphasiaClientApp.Extensions;
using AphasiaClientApp.Extensions.RequestMethod;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AphasiaClientApp.AppSettings.Settings
{
    public static class ScopedConfig
    {
        public static void Config(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped<IRequestMethod, RequestMethod>();
            builder.Services.AddScoped<ISnackbarMessage, SnackbarMessage>();
        }
    }
}
