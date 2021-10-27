using System.Collections.Generic;

namespace MusicRecommender.Recommendation.Application.Port.Out
{
    public interface IGetMusicByArtist
    {
        public List<ArtistSearchResult> GetMusicByArtist(string artistName);
    }
}
