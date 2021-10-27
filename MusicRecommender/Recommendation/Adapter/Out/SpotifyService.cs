using MusicRecommender.Common.Service;
using MusicRecommender.Recommendation.Application.Port.Out;
using System;
using System.Collections.Generic;

namespace MusicRecommender.Recommendation.Adapter.Out
{
    public class SpotifyService : IGetMusicByArtist, IGetMusicBySong, IGetMusicByGenre, IGetMusicByYear
    {
        private readonly ICustomHttpService _customHttpService;
        private const string BASE_URL = "https://api.spotify.com/v1";

        public SpotifyService(ICustomHttpService customHttpService)
        {
            _customHttpService = customHttpService;
        }

        public List<ArtistSearchResult> GetMusicByArtist(string artistName)
        {
            throw new NotImplementedException();
        }

        public List<SongSearchResult> GetMusicBySong(string songName)
        {
            throw new NotImplementedException();
        }

        public List<GenreSearchResult> GetMusicByGenre(string artistName)
        {
            throw new NotImplementedException();
        }

        public List<YearSearchResult> GetMusicByYear(string songName)
        {
            throw new NotImplementedException();
        }
    }
}
