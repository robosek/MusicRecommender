using MusicRecommender.Common;
using MusicRecommender.Common.Service;
using MusicRecommender.Recommendation.Application.Port.Out;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicRecommender.Recommendation.Adapter.Out
{
    public class SpotifyService : IMusicQuery
    {
        private readonly ICustomHttpService _customHttpService;
        private const string API_BASE_URL = "https://api.spotify.com/v1/";
        private const string ACCOUNT_API_BASE_URL = "https://accounts.spotify.com/api/";
        private readonly string ClientId;
        private readonly string ClientSecret;

        public SpotifyService(ICustomHttpService customHttpService)
        {
            _customHttpService = customHttpService;
        }

        public async Task<List<MusicSearchResult>> SearchMusic(string query, int year, string genre)
        {
            var token = GetToken();

            return null;
        }

        private async Task<BearerToken> GetToken()
        {
            var clientCredentials = new ClientCredentials(ClientId, ClientSecret);
            var accountApiUrl = new Url(ACCOUNT_API_BASE_URL, "/token");
            var tokenDto = await _customHttpService.ClientCredentialsToken<TokenDTO>(accountApiUrl, clientCredentials);

            return new BearerToken(tokenDto.access_token);
        }
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
    }

    public class TracksDTO
    {
        public List<TrackDTO> Tracks { get; set; }
    }
}
