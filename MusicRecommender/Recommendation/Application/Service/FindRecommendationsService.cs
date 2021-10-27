using MusicRecommender.Recommendation.Application.Port.In;
using MusicRecommender.Recommendation.Application.Port.Out;
using MusicRecommender.Recommendation.Domain;
using System;

namespace MusicRecommender.Recommendation.Application.Service
{
    public class FindRecommendationsService : IFindRecommendationsUseCase
    {
        private readonly IGetMusicBySong getMusicBySong;
        private readonly IGetMusicByArtist getMusicByArtist;
        private readonly IGetMusicByGenre getMusicByGenre;
        private readonly IGetMusicByYear getMusicByYear;

        public FindRecommendationsService(IGetMusicBySong getMusicBySong, 
            IGetMusicByArtist getMusicByArtist, 
            IGetMusicByGenre getMusicByGenre, 
            IGetMusicByYear getMusicByYear)
        {
            this.getMusicBySong = getMusicBySong;
            this.getMusicByArtist = getMusicByArtist;
            this.getMusicByGenre = getMusicByGenre;
            this.getMusicByYear = getMusicByYear;
        }

        public Recommendations FindRecommendations(SearchRecommendationsCommand command)
        {
            getMusicByArtist.GetMusicByArtist(command.Author);

            throw new NotImplementedException();
        }
    }
}
