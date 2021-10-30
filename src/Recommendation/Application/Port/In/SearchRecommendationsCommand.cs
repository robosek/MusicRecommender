namespace MusicRecommender.Recommendation.Application
{
    public class SearchRecommendationsCommand
    {
        public string Query { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Market { get; set; }
    }
}