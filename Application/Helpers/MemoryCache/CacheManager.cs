using Microsoft.Extensions.Caching.Memory;
using Application.Helpers;

namespace WebRecruitment.Infrastructures.Repository;

public class CacheManager : ICacheManager
{
    private readonly IMemoryCache _cache;

    public CacheManager(IMemoryCache cache)
    {
        _cache = cache;
    }

    public async Task Set(String key, object value, int time)
    {
        _cache.Set(key, value, TimeSpan.FromMinutes(time));
    }

    public async Task<T> Get<T>(string key)
    {
        return _cache.Get<T>(key);
    }

    public async Task Remove(string key)
    {
        _cache.Remove(key);
    }
}