

using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace CleanArch.Infra.RedisCache
{
    public class CachingHelper
    {
        private readonly IDistributedCache _cache;

        public CachingHelper(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task SetRecordAsync<T>(string recordId,
          T data)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = new TimeSpan(19, 0, 0)
            };

            var json = JsonConvert.SerializeObject(data);
            await _cache.SetStringAsync(recordId, json, options);

        }

        public async Task<T?> GetRecordAsync<T>(string recordId)
        {
            var json = await _cache.GetStringAsync(recordId);

            if (json is null)
                return default;

            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task RemoveRecordAsync(string recordId)
        {
            await _cache.RemoveAsync(recordId);
        }
    }
}