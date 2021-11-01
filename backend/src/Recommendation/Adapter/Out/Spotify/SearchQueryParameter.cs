using System.Text;

namespace MusicRecommender.Recommendation.Adapter.Out.Spotify
{
    internal class SearchQueryParameter
    {
        public string Query { get; }
        public int? Year { get; }
        public string Genre { get; }
        public string EndQuery { get; }

        internal SearchQueryParameter(string query, int? year, string genre)
        {
            Query = query;
            Year = year;
            Genre = genre;
            EndQuery = "&type=track";
        }

        public override string ToString()
        {
            var space = "%20";
            var queryParameters = new StringBuilder("q=");
            if (!string.IsNullOrEmpty(Query))
                queryParameters.Append($"{Query}{space}");
            if (!string.IsNullOrEmpty(Genre))
                queryParameters.Append($"genre:{Genre}{space}");
            if (Year.HasValue && Year.Value > 0)
                queryParameters.Append($"year:{Year}{space}");

            return queryParameters.Append(EndQuery).ToString();
        }
    }
}
