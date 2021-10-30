using System.Collections.Generic;

namespace MusicRecommender.Recommendation.Domain
{
    internal interface ISortRecommendationsPolicy
    {
        public IEnumerable<Recommendation> Sort(List<Recommendation> recommendations);
    }
}