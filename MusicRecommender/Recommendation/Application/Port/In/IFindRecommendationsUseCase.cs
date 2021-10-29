using MusicRecommender.Recommendation.Domain;
using System.Threading.Tasks;

namespace MusicRecommender.Recommendation.Application.Port.In
{
    public interface IFindRecommendationsUseCase
    {
        public Task<Recommendations> FindRecommendations(SearchRecommendationsCommand command);
    }
}
