namespace Storages.Contract.Interfaces;

public interface IStorageService
{
    void ClearAll();
    Task<T?> Get<T>(string key);
    void Remove(string key);
    void Save<T>(string key, T value);
}