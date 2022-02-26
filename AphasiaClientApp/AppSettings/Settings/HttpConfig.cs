using AphasiaClientApp.Models.Constant;
using AphasiaClientApp.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace AphasiaClientApp.AppSettings.Settings
{
    public static class HttpConfig
    {
        public static void Config(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(BaseUriConst.AphasiaServerUri) });
            builder.Services.AddHttpClient<IDbExerciseService,
                DbExerciseService>(client => client.BaseAddress = new Uri(BaseUriConst.AphasiaServerUri));
        }
    }
}
