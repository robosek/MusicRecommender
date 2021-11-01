using MusicRecommender.Recommendation.Adapter.In;
using System.Threading.Tasks;

namespace MusicRecommender.Recommendation.Application
{
    public interface IFindRecommendationsUseCase
    {
        public Task<RecommendationsDTO> FindRecommendations(SearchRecommendationsCommand command);
    }
}
