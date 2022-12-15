namespace CatStore.Application.Common.Interfaces.Cache;

public interface ICacheService
{
    Task SetRedisCache( string key, object value);
    Task<bool> RemoveRedisCache(string key);
    Task<T> GetRedisCache<T>(string key);
}