using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.Services.CacheService
{
    public class CacheService : ICacheService
    {

        private readonly IDatabase _database;
        //The ConnectionMultiplexer is the main arbiter of the connection to Redis inside the CLR,
        public CacheService(IConnectionMultiplexer redis)
        {
            _database=redis.GetDatabase();//In memory database.
        }

        public async Task SetCacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive)
        {

            //1)check that response contain data
            if (response is null)
                return;
            //2)serialize response => convert to json
            var options=new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var serializedResponse= JsonSerializer.Serialize(response, options);
            //3) add to redis
            await _database.StringSetAsync(cacheKey, serializedResponse, timeToLive);


        }
        public  async Task<string> getCacheResponseAsync(string cacheKey)
        {
            //find the response with that key
            var chachedResponse = await _database.StringGetAsync(cacheKey);
            
            if(chachedResponse.IsNullOrEmpty)
                return null;

            return chachedResponse;


        }

      
    }
}
