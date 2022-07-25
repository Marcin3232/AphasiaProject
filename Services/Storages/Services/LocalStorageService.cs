using Blazored.LocalStorage;
using Extensions.Base64;
using Extensions.Json;
using Storages.Contract.Interfaces;

namespace Storages.Services;

public class StorageService : IStorageService
{
    private readonly ILocalStorageService _localStorage;

    public StorageService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<T?> Get<T>(string key)
    {
        var temp = await _localStorage.GetItemAsync<string>(Base64.Encode(key));
        return temp == null ? default(T) : JsonExtension<T?>.Deserialize64(temp);
    }

    public async Task Save<T>(string key, T value)
    {
        try
        {
            await Remove(Base64.Encode(key));
        }
        catch(Exception e) { }
        var prepareValue = JsonExtension<T>.Serialize64(value);
        await _localStorage.SetItemAsync(Base64.Encode(key), prepareValue);
    }

    public async Task Remove(string key) =>
        await _localStorage.RemoveItemAsync(Base64.Encode(key));

    public async Task ClearAll() => await _localStorage.ClearAsync();

}
