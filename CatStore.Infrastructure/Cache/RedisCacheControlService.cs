using CatStore.Application.Common.Interfaces.Cache;
using Newtonsoft.Json;
using StackExchange.Redis;


namespace CatStore.Infrastructure.Cache;

public  class CacheService : ICacheService
{
    private readonly IDatabaseAsync _redis;
    
    public CacheService(IConnectionMultiplexer connectionMultiplexer)
    {
        _redis = connectionMultiplexer.GetDatabase();
    }

    public async Task SetRedisCache(string key, object value) => 
        await _redis.StringSetAsync(key, JsonConvert.SerializeObject(value));
         
    
    public async Task<T> GetRedisCache<T>(string key)
    {
        var value = await _redis.StringGetAsync(key);
        if (String.IsNullOrEmpty(value)) return default; 
        return JsonConvert.DeserializeObject<T>(value);
    }

    public async Task<bool> RemoveRedisCache(string key)
    {
        var isExists = await _redis.KeyExistsAsync(key);
        
        return isExists && 
               await _redis.KeyDeleteAsync(key);
    }
}