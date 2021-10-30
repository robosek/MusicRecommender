using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicRecommender.Recommendation.Adapter.Out.Spotify;

namespace MusicRecommender.UnitTests.Recommendation.Adapter.Out.Spotify
{
    [TestClass]
    public class SearchQueryParameterTests
    {
        [TestMethod("Should create only query parameter when only query parameter provided")]
        public void ShouldCreateOnlyQueryParameter()
        {
            var searchQueryParameter = new SearchQueryParameter("some-query",null,null);

            var query = searchQueryParameter.ToString();

            Assert.AreEqual($"q=some-query%20{searchQueryParameter.EndQuery}", query);
        }

        [TestMethod("Should create only year parameter when only year parameter provided")]
        public void ShouldCreateOnlyYearParameter()
        {
            var searchQueryParameter = new SearchQueryParameter(null, 2001, null);

            var query = searchQueryParameter.ToString();

            Assert.AreEqual($"q=year:2001%20{searchQueryParameter.EndQuery}", query);
        }

        [TestMethod("Should create only genre parameter when only genre parameter provided")]
        public void ShouldCreateOnlyGenreParameter()
        {
            var searchQueryParameter = new SearchQueryParameter(null, null, "rock");

            var query = searchQueryParameter.ToString();

            Assert.AreEqual($"q=genre:rock%20{searchQueryParameter.EndQuery}", query);
        }

        [TestMethod("Should create all parameters when all parameters provided")]
        public void ShouldCreateAllParameter()
        {
            var searchQueryParameter = new SearchQueryParameter("some-query", 2001, "rock");

            var query = searchQueryParameter.ToString();

            Assert.AreEqual($"q=some-query%20genre:rock%20year:2001%20{searchQueryParameter.EndQuery}", query);
        }

        [TestMethod("Should create empty parameters query when no parameter provied")]
        public void ShouldCreateEmptyQuery()
        {
            var searchQueryParameter = new SearchQueryParameter(null, null, null);

            var query = searchQueryParameter.ToString();

            Assert.AreEqual($"q={searchQueryParameter.EndQuery}", query);
        }
    }
}
