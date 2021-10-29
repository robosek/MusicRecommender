using System.Collections.Generic;

namespace MusicRecommender.Recommendation.Domain.Policies
{
    public interface ISortRecommendationsPolicy
    {
        public IEnumerable<Recommendation> Sort(List<Recommendation> recommendations);
    }
}