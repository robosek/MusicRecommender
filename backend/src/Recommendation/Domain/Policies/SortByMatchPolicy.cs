using System.Collections.Generic;
using System.Linq;

namespace MusicRecommender.Recommendation.Domain
{ 
    internal class SortByMatchPolicy : ISortRecommendationsPolicy
    {
        public IEnumerable<Recommendation> Sort(List<Recommendation> recommendations)
            => recommendations.OrderByDescending(recommendation => recommendation.Match);
    }
}
