using MusicRecommender.Recommendation.Application.Port.In;
using MusicRecommender.Recommendation.Application.Port.Out;
using MusicRecommender.Recommendation.Domain;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace MusicRecommender.Recommendation.Application.Service
{
    public class FindRecommendationsService : IFindRecommendationsUseCase
    {
        private readonly IMusicQuery getMusicQuery;

        public FindRecommendationsService(IMusicQuery getMusicQuery)
        {
            this.getMusicQuery = getMusicQuery;
        }

        public async Task<Recommendations> FindRecommendations(SearchRecommendationsCommand command)
        {
            var musicSearchResults = await getMusicQuery.SearchMusic(command.Author, command.Year, command.Genre);
            var recommendations = musicSearchResults.Select(music => new Domain.Recommendation(music, command.Market));

            return new Recommendations(recommendations.ToList());
        }
    }
}
