using AphasiaClientApp.AppSettings.Settings;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Threading.Tasks;

namespace AphasiaClientApp.AppSettings
{
    public class SettingsBuilder
    {
        public async Task InitializeAsync(WebAssemblyHostBuilder builder)
        {
            AppConfig.Config(builder);
            HttpConfig.Config(builder);
            SingletonConfig.Config(builder);
            ScopedConfig.Config(builder);
            LibraryConfig.Config(builder);
            AuthConfig.Config(builder);
            await builder.Build().RunAsync();
        }
    }
}
