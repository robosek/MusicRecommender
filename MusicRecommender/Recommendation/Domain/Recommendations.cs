using MusicRecommender.Recommendation.Domain.Policies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecommender.Recommendation.Domain
{
    public class Recommendations
    {
        public List<Recommendation> RecommendationCollection { get; }
        private ISortRecommendationsPolicy _sortPolicy;

        public Recommendations(List<Recommendation> recommendationCollection)
        {
            RecommendationCollection = recommendationCollection;
            _sortPolicy = new SortByMatchPolicy();
            ApplyPolicies();
        }

        private void ApplyPolicies()
        {
            _sortPolicy.Sort(RecommendationCollection);
        }
    }
}
