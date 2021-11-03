using MusicRecommender.Recommendation.Domain;
using System.Threading.Tasks;
using System.Linq;
using MusicRecommender.Recommendation.Adapter.In;

namespace MusicRecommender.Recommendation.Application
{
    internal class FindRecommendationsService : IFindRecommendationsUseCase
    {
        private readonly IMusicQuery getMusicQuery;

        public FindRecommendationsService(IMusicQuery getMusicQuery)
        {
            this.getMusicQuery = getMusicQuery;
        }

        public async Task<RecommendationsDTO> FindRecommendations(SearchRecommendationsCommand command)
        {
            var musicSearchResults = await getMusicQuery.SearchMusic(command.Query, command.Year, command.Genre);
            var recommendations = musicSearchResults.Select(music => new Domain.Recommendation(music, command.Market));

            return Map(new Recommendations(recommendations.ToList(), new SortByMatchPolicy()));
        }

        private RecommendationsDTO Map(Recommendations recommendations)
        {
            return new RecommendationsDTO
            {
                Recommendations = recommendations.RecommendationCollection.Select(rec => MapRecommendation(rec)).ToArray()
            };
        }

        private RecommendationDTO MapRecommendation(Domain.Recommendation recommendation)
        {
            return new RecommendationDTO
            {
                SongName = recommendation.SongName,
                Match = recommendation.Match,
                ReleaseDate = recommendation.ReleaseDate,
                Uri = recommendation.Metadata.Uri,
                PreviewUrl = recommendation.Metadata.PreviewUrl,
                ImageUrl = recommendation.Metadata.ImageUrl,
                Artist = recommendation.Artist
            };
        }
    }
}
