using System.Collections.Generic;
using System.Linq;

namespace MusicRecommender.Recommendation.Domain.Policies
{
    public class SortByMatchPolicy : ISortRecommendationsPolicy
    {
        public IEnumerable<Recommendation> Sort(List<Recommendation> recommendations)
            => recommendations.OrderBy(recommendation => recommendation.Match);
    }
}
