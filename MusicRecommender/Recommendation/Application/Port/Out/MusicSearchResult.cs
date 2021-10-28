using MusicRecommender.Recommendation.Adapter.Out.Spotify;

namespace MusicRecommender.Recommendation.Application.Port.Out
{
    public class MusicSearchResult
    {
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public string PreviewUrl { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
        public string[] AvailableMarkets { get; set; }

        public static MusicSearchResult Map(TrackDTO trackDto)
        {
            return new MusicSearchResult
            {
                Href = trackDto.href,
                Id = trackDto.id,
                Name = trackDto.name,
                Popularity = trackDto.popularity,
                PreviewUrl = trackDto.preview_url,
                Type = trackDto.type,
                Uri = trackDto.uri,
                AvailableMarkets = trackDto.available_markets
            };
        }
    }
}
