namespace Storages.Contract.Interfaces;

public interface IStorageService
{
    Task ClearAll();
    Task<T?> Get<T>(string key);
    Task Remove(string key);
    Task Save<T>(string key, T value);
}