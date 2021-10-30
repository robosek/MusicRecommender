using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicRecommender.Recommendation.Application;

namespace MusicRecommender.UnitTests.Recommendation.Domain
{
    [TestClass]
    public class RecommendationTests
    {
        [TestMethod("Should stay with 70% match when music available in market")]
        public void ShouldCount70PercentMatchForAvailableMarket()
        {
            var _musicSearchResult = new MusicSearchResult
            {
                Popularity = new Popularity(7, 10),
                AvailableMarkets = new string[] { "PL", "DE" }
            };

            var recommendation = new MusicRecommender.Recommendation.Domain.Recommendation(_musicSearchResult, "PL");

            Assert.AreEqual(70, recommendation.Match);
        }

        [TestMethod("Should count 30% match less when music not available in market")]
        public void ShouldCount40PercentMatchForNonAvailableMarket()
        {
            var _musicSearchResult = new MusicSearchResult
            {
                Popularity = new Popularity(7, 10),
                AvailableMarkets = new string[] { "PL", "DE" }
            };

            var recommendation = new MusicRecommender.Recommendation.Domain.Recommendation(_musicSearchResult, "NO");

            Assert.AreEqual(70-30, recommendation.Match);
        }

        [TestMethod("Should properly count match for factor 1000")]
        public void ShouldCount90PercentMatchForAvailableMarket()
        {
            var _musicSearchResult = new MusicSearchResult
            {
                Popularity = new Popularity(900, 1000),
                AvailableMarkets = new string[] { "PL", "DE" }
            };

            var recommendation = new MusicRecommender.Recommendation.Domain.Recommendation(_musicSearchResult, "PL");

            Assert.AreEqual(90, recommendation.Match);
        }

        [TestMethod("Should properly count minus match for factor 1000")]
        public void ShouldCountMinusPercentMatchForAvailableMarket()
        {
            var _musicSearchResult = new MusicSearchResult
            {
                Popularity = new Popularity(200, 1000),
                AvailableMarkets = new string[] { "PL", "DE" }
            };

            var recommendation = new MusicRecommender.Recommendation.Domain.Recommendation(_musicSearchResult, "NO");

            Assert.AreEqual(-10, recommendation.Match);
        }
    }
}
