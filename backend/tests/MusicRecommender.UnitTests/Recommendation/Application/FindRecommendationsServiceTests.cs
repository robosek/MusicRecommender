using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using MusicRecommender.Recommendation.Application;

namespace MusicRecommender.UnitTests.Recommendation.Application
{
    [TestClass]
    public class FindRecommendationsServiceTests
    {
        private List<MusicSearchResult> _musicSearchResults = new()
        {
            new()
            {
                Name = "Some name 1",
                ReleaseDate = "02/02/2001",
                Popularity = new Popularity(70,100),
                AvailableMarkets = new[] {"PL"}
            },
            new()
            {
                Name = "Some name 2",
                ReleaseDate = "02/02/2001",
                Popularity = new Popularity(30, 100),
                AvailableMarkets = new[] { "PL"}
            },
        };

        [TestMethod("Should find two recommendations when correct paramters provided.")]
        public async Task ShouldFindTwoRecommendations()
        {
            var musicQueryStub = new Mock<IMusicQuery>();
            musicQueryStub.Setup(x => x.SearchMusic("Some name",2001,null)).ReturnsAsync(_musicSearchResults);
            var findRecommendationsService = new FindRecommendationsService(musicQueryStub.Object);
            var searchCommand = new SearchRecommendationsCommand()
            {
                Year = 2001,
                Query = "Some name",
                Genre = null,
                Market = "PL"
            };


            var recommendations = await findRecommendationsService.FindRecommendations(searchCommand);

            Assert.AreEqual(2, recommendations.Recommendations.Length);
        }

        [TestMethod("Should respond with empty list of recommendations when not recommendation found.")]
        public async Task ShouldRespondWithEmptyRecommendationsList()
        {
            var musicQueryStub = new Mock<IMusicQuery>();
            musicQueryStub.Setup(x => x.SearchMusic("Some name", 2001, null)).ReturnsAsync(new List<MusicSearchResult>());
            var findRecommendationsService = new FindRecommendationsService(musicQueryStub.Object);
            var searchCommand = new SearchRecommendationsCommand()
            {
                Year = 2001,
                Query = "Some name",
                Genre = null,
                Market = "PL"
            };


            var recommendations = await findRecommendationsService.FindRecommendations(searchCommand);

            Assert.AreEqual(0, recommendations.Recommendations.Length);
        }
    }
}
