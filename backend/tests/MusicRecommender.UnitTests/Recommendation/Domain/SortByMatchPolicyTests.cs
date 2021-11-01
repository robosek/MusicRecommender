using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicRecommender.Recommendation.Application;
using MusicRecommender.Recommendation.Domain;
using System.Collections.Generic;

namespace MusicRecommender.UnitTests.Recommendation.Domain
{
    [TestClass]
    public class SortByMatchPolicyTests
    {
        [TestMethod("Should sort by match when two recommendations provided")]
        public void ShouldSortByMatchValueCorrectly()
        {
            var _musicSearchResult1 = new MusicSearchResult
            {
                Popularity = new Popularity(7, 10),
                AvailableMarkets = new string[] { "PL", "DE" }
            };
            var recommendation1 = new MusicRecommender.Recommendation.Domain.Recommendation(_musicSearchResult1, "PL");
            var _musicSearchResult2 = new MusicSearchResult
            {
                Popularity = new Popularity(6, 10),
                AvailableMarkets = new string[] { "PL", "DE" }
            };
            var recommendation2 = new MusicRecommender.Recommendation.Domain.Recommendation(_musicSearchResult2, "PL");


            var recommendations = new Recommendations(
                new List<MusicRecommender.Recommendation.Domain.Recommendation>() { recommendation1, recommendation2}, 
                new SortByMatchPolicy());



            Assert.AreEqual(recommendations.RecommendationCollection[0], recommendation1);
            Assert.AreEqual(recommendations.RecommendationCollection[1], recommendation2);
        }
    }
}
