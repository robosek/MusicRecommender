using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicRecommender.Common;
using MusicRecommender.Recommendation.Application;

namespace MusicRecommender.Recommendation.Adapter.In
{
    [ApiController]
    [Route("api/recommendation")]
    [Produces("application/json")]
    internal class FindRecommendationsController : ControllerBase
    {
        private readonly IFindRecommendationsUseCase _findRecommendations;
        public FindRecommendationsController(IFindRecommendationsUseCase findRecommendations)
        {
            _findRecommendations = findRecommendations;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseEnvelop<RecommendationsDTO>>> FindRecommendations([FromQuery] SearchRecommendationsCommand command)
        {
            if(IsInvalidModel(command))
                return BadRequest(new ResponseEnvelop<RecommendationsDTO>(400, "There should be at least one parameter provided", null));
            
            if(IsNoMakretProvided(command))
                return BadRequest(new ResponseEnvelop<RecommendationsDTO>(400, "Market parameter should be provided", null));
     
            return Ok(new ResponseEnvelop<RecommendationsDTO>(200, null, await _findRecommendations.FindRecommendations(command)));
        }

        private bool IsInvalidModel(SearchRecommendationsCommand command)
         => 
                command == null ||
                string.IsNullOrEmpty(command.Query)
                && string.IsNullOrEmpty(command.Genre)
                && command.Year <= 0;

        private bool IsNoMakretProvided(SearchRecommendationsCommand command)
              => string.IsNullOrEmpty(command.Market);

    }
}