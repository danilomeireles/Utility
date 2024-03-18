using Microsoft.Extensions.Caching.Memory;
using System;

namespace Utility.Util
{ 
    public sealed class CacheManager<T>
    {
        private static CacheManager<T> _instance;
        private static readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        private CacheManager()
        {
        }
        
        public static CacheManager<T> Instance
        {
            get
            {
                lock (_cache)
                {
                    return _instance ??= new CacheManager<T>();
                }
            }
        }

        public void SetItem(string key, T value, DateTimeOffset absoluteExpiration)
        {
            _cache.Set(key, value, absoluteExpiration);
        }
       
        public T GetItem(string key)
        {
            return _cache.Get<T>(key);
        }

       
        public void RemoveItem(string key)
        {
            _cache.Remove(key);
        }
    }
}