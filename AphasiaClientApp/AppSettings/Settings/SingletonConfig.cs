using AphasiaClientApp.Extensions.Navigation;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace AphasiaClientApp.AppSettings.Settings
{
    public static class SingletonConfig
    {
        public static void Config(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddSingleton<Navigation>();
            builder.Services.AddSingleton(serviceProvider => (IJSInProcessRuntime)serviceProvider.GetRequiredService<IJSRuntime>());
            builder.Services.AddSingleton(serviceProvider => (IJSUnmarshalledRuntime)serviceProvider.GetRequiredService<IJSRuntime>());
        }
    }
}
