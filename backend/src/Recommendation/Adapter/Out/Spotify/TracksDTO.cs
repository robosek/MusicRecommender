using System.Collections.Generic;

namespace MusicRecommender.Recommendation.Adapter.Out.Spotify
{
    public class RootDTO
    {
        public TracksDTO tracks { get; set; }
    }

    public class TracksDTO
    {
        public string href { get; set; }
        public List<ItemDTO> items { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }
    }

    public class TokenDTO
    {
        public string access_token { get; set; }
    }

    public class ImageDTO
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }


    public class AlbumDTO
    {
        public string album_type { get; set; }
        public List<ArtistDTO> artists { get; set; }
        public List<string> available_markets { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public List<ImageDTO> images { get; set; }
        public string name { get; set; }
        public string release_date { get; set; }
        public string release_date_precision { get; set; }
        public int total_tracks { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class ArtistDTO
    {
        public string Id { get; set; }
        public string name { get; set; }
    }

    public class ArtistsDTO
    {
        public List<ArtistDTO> Artists { get; set; }
    }

    public class ItemDTO
    {
        public AlbumDTO album { get; set; }
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
        public List<string> available_markets { get; set; }
    }
}
