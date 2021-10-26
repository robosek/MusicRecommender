using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecommender.Recommendation.Domain
{
    public class Recommendation
    {
        public int Author { get; }

        public int SongName { get; }

        public int Popularity { get; }
        public Priority Priority { get; }
        
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
