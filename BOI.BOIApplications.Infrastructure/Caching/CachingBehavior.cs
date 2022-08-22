using BOI.BOIApplications.Application.Contracts.Infrastructure;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Infrastructure.Caching
{
    public sealed class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheableMediatrQuery
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger _logger;
        public CachingBehavior(IDistributedCache cache, ILogger<TResponse> logger)
        {
            _cache = cache;
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response;
            if (request.BypassCache) return await next();
            async Task<TResponse> GetResponseAndAddToCache()
            {
                response = await next();
                var slidingExpiration = request.SlidingExpiration == null ? TimeSpan.FromSeconds(30) : request.SlidingExpiration;
                var options = new DistributedCacheEntryOptions { SlidingExpiration = slidingExpiration };
                var serializedData = Encoding.Default.GetBytes(JsonConvert.SerializeObject(response));
                await _cache.SetAsync(request.CacheKey, serializedData, options, cancellationToken);
                return response;
            }

            var cachedResponse = await _cache.GetAsync(request.CacheKey, cancellationToken);
            if (cachedResponse != null)
            {
                response = JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString(cachedResponse));
                _logger.LogInformation($"Fetched from Cache -> '{request.CacheKey}'.");
            }
            else
            {
                response = await GetResponseAndAddToCache();
                _logger.LogInformation($"Added to Cache -> '{request.CacheKey}'.");
            }
            return response;
        }
    }
}
