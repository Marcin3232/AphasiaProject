using AphasiaClientApp.Extensions;
using AphasiaClientApp.Extensions.RequestMethod;
using AphasiaClientApp.Features.AuthProviders;
using AphasiaClientApp.Features.AuthService;
using AphasiaClientApp.Models.Constant;
using AphasiaClientApp.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AphasiaClientApp
{
    public class InitBuilder
    {
        public async Task InitializeAsync(WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(BaseUriConst.AphasiaServerUri) });

            builder.Services.AddMudServices();
            builder.Services.AddScoped<IRequestMethod, RequestMethod>();
            builder.Services.AddScoped<ISnackbarMessage, SnackbarMessage>();
            builder.Services.AddHttpClient<IDbExerciseService, DbExerciseService>(client => client.BaseAddress = new Uri(BaseUriConst.AphasiaServerUri));

            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

            builder.Services.AddLocalization();

            await builder.Build().RunAsync();
        }
    }
}
