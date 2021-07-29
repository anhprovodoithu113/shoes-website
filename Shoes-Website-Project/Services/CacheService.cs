using System;
using Shoes_Website.Domain.Intefaces;
using Microsoft.Extensions.Caching.Memory;

namespace Shoes_Website_Project.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T GetFromCache<T>(string key)
        {
            return _memoryCache.TryGetValue(key, out T cachedObject) ? cachedObject : default(T);
        }

        public void RemoveCache(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveManyCache(params string[] keys)
        {
            foreach (var k in keys)
            {
                _memoryCache.Remove(k);
            }
        }

        public void SetCache<T>(string key, T cachedObject, int slidingOption)
        {
            var options = new MemoryCacheEntryOptions { AbsoluteExpiration = DateTimeOffset.Now.AddHours(slidingOption) };
        }
    }
}
