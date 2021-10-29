namespace MusicRecommender.Recommendation.Adapter.In
{
    public class RecommendationsDTO
    {
        public RecommendationDTO[] Recommendations { get; set; }
    }

    public class RecommendationDTO
    {
        public string SongName { get; }
        public double Match { get; }
        public int Year { get; }
        public string PreviewUrl { get; set; }
        public string Uri { get; set; }
    }
}
