using MusicRecommender.Recommendation.Domain;

namespace MusicRecommender.Recommendation.Application.Port.In
{
    interface IFindRecommendationsUseCase
    {
        public Recommendations FindRecommendations(SearchRecommendationsCommand command);
    }
}
