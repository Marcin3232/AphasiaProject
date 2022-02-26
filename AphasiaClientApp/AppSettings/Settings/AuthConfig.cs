using AphasiaClientApp.Features.AuthProviders;
using AphasiaClientApp.Features.AuthService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AphasiaClientApp.AppSettings.Settings
{
    public static class AuthConfig
    {
        public static void Config(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
        }
    }
}
