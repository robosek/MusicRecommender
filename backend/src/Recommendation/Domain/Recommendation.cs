using MusicRecommender.Recommendation.Application;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MusicRecommender.UnitTests")]
namespace MusicRecommender.Recommendation.Domain
{
    internal class Recommendation
    {
        public string SongName { get; }
        public double Match { get; }
        public string ReleaseDate { get; }
        public string Artist { get; }
        public RecommendationMetadata Metadata { get; }

        private readonly string[] _availableMarkets;
        private readonly string _targetMarket;
        private const int MATCH_FACTOR = 100;
        
        internal Recommendation(MusicSearchResult musicSearchResult, string targetMarket)
        {
            SongName = musicSearchResult.Name;
            ReleaseDate = musicSearchResult.ReleaseDate;
            Artist = musicSearchResult.Artist;
            Metadata = new RecommendationMetadata
            {
                Uri = musicSearchResult.Uri,
                Href = musicSearchResult.Href,
                PreviewUrl = musicSearchResult.PreviewUrl,
                ImageUrl = musicSearchResult.ImageUrl
            };
            _availableMarkets = musicSearchResult.AvailableMarkets;
            _targetMarket = targetMarket;
            Match = CountRecommendationMatch(musicSearchResult.Popularity);
        }

        private double CountRecommendationMatch(Popularity popluarity)
        {
            var availableInTargetMarket = _availableMarkets.Select(market => market.ToLower()).Contains(_targetMarket.ToLower());
            var adjustedPopularityValue = (popluarity.Value / (double) popluarity.MaxValue) * MATCH_FACTOR;

            return availableInTargetMarket ? adjustedPopularityValue : adjustedPopularityValue - 30;
        }
    }
}