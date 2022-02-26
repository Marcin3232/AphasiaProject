using AphasiaClientApp.Extensions.Navigation;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AphasiaClientApp.AppSettings.Settings
{
    public static class SingletonConfig
    {
        public static void Config(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddSingleton<Navigation>();
        }
    }
}
