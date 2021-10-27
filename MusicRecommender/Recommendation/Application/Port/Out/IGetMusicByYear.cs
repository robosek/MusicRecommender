using System.Collections.Generic;

namespace MusicRecommender.Recommendation.Application.Port.Out
{
    public interface IGetMusicByYear
    {
        public List<YearSearchResult> GetMusicByYear(string songName);
    }
}
