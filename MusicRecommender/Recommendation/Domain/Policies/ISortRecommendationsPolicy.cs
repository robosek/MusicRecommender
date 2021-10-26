using System.Collections.Generic;

namespace MusicRecommender.Recommendation.Domain.Policies
{
    interface ISortRecommendationsPolicy
    {
        IEnumerable<Recommendation> Sort(List<Recommendation> recommendations);
    }
}
