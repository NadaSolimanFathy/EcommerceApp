using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.CacheService
{
    public interface ICacheService
    {
        //                            key             value          time to stay in memory
        Task SetCacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive);
        Task<string> getCacheResponseAsync(string cacheKey);

    }
}
