using AphasiaClientApp.AppSettings;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Threading.Tasks;

namespace AphasiaClientApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await new SettingsBuilder()
                .InitializeAsync(WebAssemblyHostBuilder.CreateDefault(args));
        }
    }
}
