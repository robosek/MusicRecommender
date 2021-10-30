namespace MusicRecommender.Recommendation.Adapter.In
{
    public class RecommendationsDTO
    {
        public RecommendationDTO[] Recommendations { get; set; }
    }

    public class RecommendationDTO
    {
        public string SongName { get; set; }
        public double Match { get; set; }
        public string ReleaseDate { get; set; }
        public string PreviewUrl { get; set; }
        public string Uri { get; set; }
        public string ImageUrl { get; set; }
        public string Artist { get; set; }
    }
}
