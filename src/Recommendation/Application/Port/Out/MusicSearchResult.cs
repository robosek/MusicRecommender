using MusicRecommender.Recommendation.Adapter.Out.Spotify;
using System;
using System.Linq;

namespace MusicRecommender.Recommendation.Application
{
    public class MusicSearchResult
    {
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public Popularity Popularity { get; set; }
        public string PreviewUrl { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
        public string ReleaseDate { get; set; }
        public string Artist { get; set;  }
        public string ImageUrl { get; set; }
        public string[] AvailableMarkets { get; set; }

        public static MusicSearchResult Map(ItemDTO trackDto)
        {
            return new MusicSearchResult
            {
                Href = trackDto.href,
                Id = trackDto.id,
                Name = trackDto.name,
                Popularity = new Popularity(trackDto.popularity, 100),
                PreviewUrl = trackDto.preview_url,
                Type = trackDto.type,
                Uri = trackDto.uri,
                ReleaseDate = trackDto.album.release_date,
                AvailableMarkets = trackDto.available_markets.ToArray(),
                ImageUrl = trackDto.album.images.Any() ? trackDto.album.images[0].url : null,
                Artist = trackDto.album.artists.Any() ? trackDto.album.artists[0].name : null
            };
        }
    }

    public class Popularity
    {
        public int Value { get; }
        public int MaxValue { get; }

        public Popularity(int value, int maxValue)
        {
            Value = value;
            MaxValue = maxValue;
        }
    }
}
