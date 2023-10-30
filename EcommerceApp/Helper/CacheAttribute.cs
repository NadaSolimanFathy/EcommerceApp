using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Services.CacheService;
using System.Text;

namespace EcommerceApp.Helper
{
    public class CacheAttribute:Attribute ,IAsyncActionFilter
    {
        private readonly int _timeToLiveInSeconds;

        public CacheAttribute(int timeToLiveInSeconds)
        {
           _timeToLiveInSeconds = timeToLiveInSeconds;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context,ActionExecutionDelegate next)
        {//replacment of injection
            var chacheService=context.HttpContext.RequestServices.GetRequiredService<ICacheService>();
            //key generation ====== object key will bw always the same
            var chachKey= GenerateCacheKeyFromRequest(context.HttpContext.Request);
            //search by cache key to find if it's already has value or not
            var cachedResponse = await chacheService.getCacheResponseAsync(chachKey);
            if (!string.IsNullOrEmpty(cachedResponse))
            {//value found so we will retreive it
                var contentResult = new ContentResult
                {
                    Content = cachedResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = contentResult;
                return;
            }
            var executedContext = await next();

            if (executedContext.Result is OkObjectResult response)//the return is good
            {
                await chacheService.SetCacheResponseAsync(chachKey, response.Value, TimeSpan.FromSeconds(_timeToLiveInSeconds));
            }
        }

        private string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            var chacheKey = new StringBuilder();
            chacheKey.Append($"{request.Path}");
            //foreach( var (key, value) in request.Query.OrderBy(x=>x. key))
            //{

            //}
            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                chacheKey.Append($"| {key} - {value}");
            }

            return chacheKey.ToString();
        }
    }

}
