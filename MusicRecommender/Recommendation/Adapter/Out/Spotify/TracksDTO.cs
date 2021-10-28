using System.Collections.Generic;

namespace MusicRecommender.Recommendation.Adapter.Out.Spotify
{
    public class TracksDTO
    {
        public List<TrackDTO> Tracks { get; set; }
    }

    public class TokenDTO
    {
        public string access_token { get; set; }
    }

    public class ArtistDTO
    {
        public string Id { get; set; }
    }

    public class ArtistsDTO
    {
        public List<ArtistDTO> Artists { get; set; }
    }

    public class TrackDTO
    {
        public int disc_number { get; set; }
        public int duration_ms { get; set; }
        public bool @explicit { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string preview_url { get; set; }
        public int track_number { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
        public string[] available_markets { get; set; }
    }
}
