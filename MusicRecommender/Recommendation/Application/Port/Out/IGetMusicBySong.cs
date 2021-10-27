using System.Collections.Generic;

namespace MusicRecommender.Recommendation.Application.Port.Out
{
    public interface IGetMusicBySong
    {
        public List<SongSearchResult> GetMusicBySong(string songName);
    }
}
