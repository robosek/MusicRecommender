using System.Collections.Generic;

namespace MusicRecommender.Recommendation.Application.Port.Out
{
    public interface IGetMusicByGenre
    {
        public List<GenreSearchResult> GetMusicByGenre(string artistName);
    }
}
