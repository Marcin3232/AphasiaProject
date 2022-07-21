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
        return JsonExtension<T?>.Deserialize64(temp);
    }

    public void Save<T>(string key, T value)
    {
        var prepareValue = JsonExtension<T>.Serialize64(value);
        _localStorage.SetItemAsync(Base64.Encode(key), Base64.Encode(prepareValue));
    }

    public async void Remove(string key) =>
        await _localStorage.RemoveItemAsync(Base64.Encode(key));

    public async void ClearAll() => await _localStorage.ClearAsync();

}
