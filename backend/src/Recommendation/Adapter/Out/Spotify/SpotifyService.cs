using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MusicRecommender.Common;
using MusicRecommender.Common.Service;
using MusicRecommender.Recommendation.Application;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecommender.Recommendation.Adapter.Out.Spotify
{
    internal class SpotifyService : IMusicQuery
    {
        private readonly ICustomHttpService _customHttpService;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;
        private const string API_BASE_URL = "https://api.spotify.com/v1/";
        private const string ACCOUNT_API_BASE_URL = "https://accounts.spotify.com/api/";
        private readonly string ClientId;
        private readonly string ClientSecret;
        private const string TOKEN_KEY = "TOKEN";

        public SpotifyService(ICustomHttpService customHttpService, 
            IConfiguration configuration, IMemoryCache memoryCache)
        {
            _customHttpService = customHttpService;
            _configuration = configuration;
            _memoryCache = memoryCache;
            ClientId = _configuration["SpotifyClientCredentials:ClientId"];
            ClientSecret = _configuration["SpotifyClientCredentials:ClientSecret"];
        }

        public async Task<List<MusicSearchResult>> SearchMusic(string query, int? year, string genre)
        {
            var token = GetTokenFromCache();
            if (token == null)
            {
                token = await GetTokenAsync();
                _memoryCache.Set(TOKEN_KEY, token, token.ExpiresIn);
            }
            var searchQueryParameters = new SearchQueryParameter(query,year,genre);
            var endpointWithQuery = $"/search?{searchQueryParameters}";
            var apiUrl = new Url(API_BASE_URL, endpointWithQuery);
            var tracks = await _customHttpService.GetDataAsync<RootDTO>(apiUrl, token);

            return tracks.tracks.items.Select(track => MusicSearchResult.Map(track)).ToList();
        }

        private async Task<BearerToken> GetTokenAsync()
        {
            var clientCredentials = new ClientCredentials(ClientId, ClientSecret);
            var accountApiUrl = new Url(ACCOUNT_API_BASE_URL, "/token");
            var tokenDto = await _customHttpService.ClientCredentialsToken<TokenDTO>(accountApiUrl, clientCredentials);

            return new BearerToken(tokenDto.access_token, tokenDto.expires_in);
        }

        private BearerToken GetTokenFromCache()
        {
            _memoryCache.TryGetValue(TOKEN_KEY, out BearerToken bearerToken);

            return bearerToken;
        }
    }
}
