namespace MusicRecommender.Recommendation.Application.Port.In
{
    public class SearchRecommendationsCommand
    {
        public string Author { get; set; }
        public string Song { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
    }
}