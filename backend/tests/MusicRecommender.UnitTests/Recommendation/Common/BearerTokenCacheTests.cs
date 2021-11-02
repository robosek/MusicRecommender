using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicRecommender.Common;

namespace MusicRecommender.UnitTests.Recommendation.Common
{
    [TestClass]
    public class BearerTokenCacheTests
    {
        private readonly IMemoryCache _memoryCache;
        public BearerTokenCacheTests()
        {
            _memoryCache = PrepareMemoryCache();
        }

        [TestMethod("Should add and retrieve valid bearer token")]
        public void ShouldAddAndRetrieveValidToken()
        {
            var bearerToken = new BearerToken("value", 3600);
            _memoryCache.Set("key",bearerToken, bearerToken.ExpiresIn);

            _memoryCache.TryGetValue("key", out BearerToken resultToken);

            Assert.IsTrue(resultToken != null);
            Assert.AreEqual("value", resultToken.Value);
        }

        [TestMethod("Should add but not retrieve expired bearer token")]
        public void ShouldAddAndNotRetrieveExpiredToken()
        {
            var bearerToken = new BearerToken("value", -1);
            _memoryCache.Set("key", bearerToken, bearerToken.ExpiresIn);

            _memoryCache.TryGetValue("key", out BearerToken resultToken);

            Assert.IsTrue(resultToken == null);
        }

        private static IMemoryCache PrepareMemoryCache()
        {
            var services = new ServiceCollection();
            services.AddMemoryCache();
            var serviceProvider = services.BuildServiceProvider();

            var memoryCache = serviceProvider.GetService<IMemoryCache>();
            return memoryCache;
        }
    }
}
