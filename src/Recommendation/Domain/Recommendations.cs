using System.Collections.Generic;
using System.Linq;

namespace MusicRecommender.Recommendation.Domain
{
    internal class Recommendations
    {
        public List<Recommendation> RecommendationCollection { get; }
        private ISortRecommendationsPolicy _sortPolicy;

        public Recommendations(List<Recommendation> recommendationCollection, ISortRecommendationsPolicy sortPolicy)
        {
            _sortPolicy = sortPolicy;
            RecommendationCollection = ApplyPolicies(recommendationCollection).ToList();
           
        }

        private IEnumerable<Recommendation> ApplyPolicies(List<Recommendation> recommendationCollection)
        {
            return _sortPolicy.Sort(recommendationCollection);
        }
    }
}
