using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Core.CrossCuttingConcerns.Caching
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;
        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public T? Get<T>(string key)
        {
            string? serializedData = _cache.GetString(key);

            if (!string.IsNullOrEmpty(serializedData))
            {
                return JsonSerializer.Deserialize<T>(serializedData);
            }

            return default;
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
            string serializedData = JsonSerializer.Serialize(data);

            if (duration != null)
            {
                _cache.SetString(key, serializedData, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = duration
                });
            }
            else
            {
                _cache.SetString(key, serializedData);
            }
        }
    }
}
