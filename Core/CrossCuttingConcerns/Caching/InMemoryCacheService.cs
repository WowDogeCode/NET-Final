using Microsoft.Extensions.Caching.Memory;

namespace Core.CrossCuttingConcerns.Caching
{
    public class InMemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _cache;
        public InMemoryCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public T? Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public bool IsExists(string key)
        {
            return _cache.Get(key) != null;
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void Set<T>(string key, T data, TimeSpan? duration = null)
        {
            if(duration != null)
            {
                _cache.Set<T>(key, data, duration.Value);
            }
            else
            {
                _cache.Set<T>(key, data);
            }
        }
    }
}
