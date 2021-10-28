using System.Text;

namespace MusicRecommender.Recommendation.Adapter.Out.Spotify
{
    //q=[query]||[year:2001]||[genre:rock]
    public class SearchQueryParameter
    {
        public string Query { get; }
        public int? Year { get; }
        public string Genre { get; }

        public SearchQueryParameter(string query, int? year, string genre)
        {
            Query = query;
            Year = year;
            Genre = genre;
        }

        public override string ToString()
        {
            var space = "%20";
            var queryParameters = new StringBuilder("q=");
            if (!string.IsNullOrEmpty(Query))
                queryParameters.Append($"{Query}{space}");
            if (Year.HasValue && Year.Value > 0)
                queryParameters.Append($"{Year}{space}");

            return queryParameters.ToString();
        }
    }
}
