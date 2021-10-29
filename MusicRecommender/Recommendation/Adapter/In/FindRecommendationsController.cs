using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicRecommender.Recommendation.Application.Port.In;
using MusicRecommender.Recommendation.Domain;
using System.Linq;

namespace MusicRecommender.Recommendation.Adapter.In
{
    [ApiController]
    [Route("[controller]")]
    public class FindRecommendationsController : ControllerBase
    {
        private readonly IFindRecommendationsUseCase _findRecommendations;
        public FindRecommendationsController(IFindRecommendationsUseCase findRecommendations)
        {
            _findRecommendations = findRecommendations;
        }

        [HttpGet]
        public async Task<Recommendations> FindRecommendations([FromBody] SearchRecommendationsCommand command)
        {
            return await _findRecommendations.FindRecommendations(command);

        }

        //private RecommendationsDTO Map(Recommendations recommendations)
        //{
        //    return new RecommendationsDTO
        //    {
        //        Recommendations = recommendations.RecommendationCollection.Select(rec => MapRec(rec));
        //    };
        //}

        //private RecommendationDTO MapRec(Domain.Recommendation recommendation)
        //{
            
        //}
    }
}