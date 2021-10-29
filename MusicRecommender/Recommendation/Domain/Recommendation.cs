using MusicRecommender.Recommendation.Application.Port.Out;
using System.Linq;

namespace MusicRecommender.Recommendation.Domain
{
    public class Recommendation
    {
        public string SongName { get; }
        public double Match { get; }
        public int Year { get; }
        public RecommendationMetadata Metadata { get; }

        private readonly string[] _availableMarkets;
        private readonly string _targetMarket;
        private const int MATCH_FACTOR = 100;
        
        public Recommendation(MusicSearchResult musicSearchResult, string targetMarket)
        {
            SongName = musicSearchResult.Name;
            Year = musicSearchResult.ReleaseDate.Year;
            Metadata = new RecommendationMetadata
            {
                Uri = musicSearchResult.Uri,
                Href = musicSearchResult.Href,
                PreviewUrl = musicSearchResult.PreviewUrl
            };
            _availableMarkets = musicSearchResult.AvailableMarkets;
            _targetMarket = targetMarket;
            Match = CountRecommendationMatch(musicSearchResult.Popularity);
        }

        private double CountRecommendationMatch(Popluarity popluarity)
        {
            var availableInTargetMarket = _availableMarkets.Select(market => market.ToLower()).Contains(_targetMarket.ToLower());
            var adjustedPopularityValue = (popluarity.Value / (double) popluarity.MaxValue) * MATCH_FACTOR;

            return availableInTargetMarket ? adjustedPopularityValue : adjustedPopularityValue - 30;
        }
    }
}
