using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Storages.Contract.Interfaces;
using Storages.Services;

namespace Storages;

public static class StorageDI
{
    public static void AddStorageService(this WebAssemblyHostBuilder builder)
    {

        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddScoped<IStorageService, StorageService>();
    }
}