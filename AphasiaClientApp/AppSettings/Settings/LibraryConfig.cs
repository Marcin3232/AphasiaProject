using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace AphasiaClientApp.AppSettings.Settings
{
    public static class LibraryConfig
    {
        public static void Config(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddMudServices();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddLocalization();
        }
    }
}
