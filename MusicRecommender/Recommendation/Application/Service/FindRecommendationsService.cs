using MusicRecommender.Recommendation.Application.Port.In;
using MusicRecommender.Recommendation.Application.Port.Out;
using MusicRecommender.Recommendation.Domain;
using System;

namespace MusicRecommender.Recommendation.Application.Service
{
    public class FindRecommendationsService : IFindRecommendationsUseCase
    {
        private readonly IMusicQuery getMusicQuery;

        public FindRecommendationsService(IMusicQuery getMusicQuery)
        {
            this.getMusicQuery = getMusicQuery;
        }

        public Recommendations FindRecommendations(SearchRecommendationsCommand command)
        {
            getMusicQuery.SearchMusic(command.Author, command.Year, command.Genre);

            throw new NotImplementedException();
        }
    }
}
