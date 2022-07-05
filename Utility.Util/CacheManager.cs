using Microsoft.Extensions.Caching.Memory;
using System;

namespace Utility.Util
{
    /// <summary>
    /// A simple memory cache manager
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    public sealed class CacheManager<T>
    {
        private static CacheManager<T> _instance;
        private static readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        private CacheManager()
        {
        }

        /// <summary>
        /// The singleton instance
        /// </summary>
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

        /// <summary>
        /// Sets an item in the memory cache
        /// </summary>
        /// <param name="key">The object unique key</param>
        /// <param name="value">The object instance</param>
        /// <param name="absoluteExpiration">The memory cache expiration. Example: DateTimeOffset.Now.AddMinutes(5)</param>
        public void SetItem(string key, T value, DateTimeOffset absoluteExpiration)
        {
            _cache.Set(key, value, absoluteExpiration);
        }

        /// <summary>
        /// Gets an object by it's key
        /// </summary>
        /// <param name="key">The item unique key</param>
        /// <returns></returns>
        public T GetItem(string key)
        {
            return _cache.Get<T>(key);
        }

        /// <summary>
        /// Removes the object associated with the given key
        /// </summary>
        /// <param name="key">The object key</param>
        public void RemoveItem(string key)
        {
            _cache.Remove(key);
        }
    }
}