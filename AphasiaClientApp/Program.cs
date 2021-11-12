using AphasiaClientApp.Extensions.RequestMethod;
using AphasiaClientApp.Models.Constant;
using AphasiaClientApp.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AphasiaClientApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddMudServices();

            builder.Services.AddScoped<IRequestMethod, RequestMethod>();
            builder.Services.AddHttpClient<IDbExerciseService, DbExerciseService>(client => client.BaseAddress = new Uri(BaseUriConst.AphasiaServerUri));

            await builder.Build().RunAsync();
        }
    }
}
