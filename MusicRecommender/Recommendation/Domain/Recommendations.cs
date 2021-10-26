using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecommender.Recommendation.Domain
{
    public class Recommendations
    {
        public List<Recommendation> RecommendationCollection { get; }

        public Recommendations(List<Recommendation> recommendationCollection)
        {
            RecommendationCollection = recommendationCollection;
            ApplyPolicies();
        }

        public void AddRecommendation(Recommendation recommendation)
        {
            ApplyPolicies();
        }

        public void RemoveRecommendation(Recommendation recommendation)
        {
            ApplyPolicies();
        }

        private void ApplyPolicies()
        {

        }
    }
}
