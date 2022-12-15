using CatStore.Application.Common.Interfaces.Cache;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace CatStore.Infrastructure.Services;



public  class CacheService : ICacheService
{
    private readonly IDatabaseAsync _redis;
    
    public CacheService(IConnectionMultiplexer connectionMultiplexer)
    {
        _redis = connectionMultiplexer.GetDatabase();
    }
    
    public  async Task SetRedisCache( string key, object value) => 
        await _redis.StringSetAsync(key, JsonConvert.SerializeObject(value));

    public async Task<T> GetRedisCache<T>(string key)
    {
        var redisCacheData = await _redis.StringGetAsync(key);
        if (String.IsNullOrEmpty(redisCacheData)) return default; 
        return JsonConvert.DeserializeObject<T>(await _redis.StringGetAsync(key));
    }

    public async Task<bool> RemoveRedisCache(string key)
    {
        var isExists = await _redis.KeyExistsAsync(key);
        
        return isExists && 
               await _redis.KeyDeleteAsync(key);
    }
}