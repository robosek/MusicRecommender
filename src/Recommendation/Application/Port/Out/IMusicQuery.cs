using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicRecommender.Recommendation.Application
{
    public interface IMusicQuery
    {
        public Task<List<MusicSearchResult>> SearchMusic(string query, int? year, string genre);
    }
}
