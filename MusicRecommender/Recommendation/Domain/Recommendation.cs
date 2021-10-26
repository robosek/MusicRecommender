using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecommender.Recommendation.Domain
{
    public class Recommendation
    {
        public string Author { get; }
        public string SongName { get; }
        public int Popularity { get; }
        public string Genre { get; }
        public int Year { get; set; }
        public Priority Priority { get; }
        
        private Recommendation(string author, string songName, string genre, int year, int popluarity, Priority priority)
        {
            Author = author;
            SongName = songName;
            Genre = genre;
            Year = year;
            Popularity = popluarity;
            Priority = priority;
        }

        //public static Recommendation Create(AuthorSearchResult authorSearchResult)
        //{
        //    return new Recommendation();
        //}
        //public static Recommendation Create(SongNameSearchResult authorSearchResult)
        //{
        //    return new Recommendation();
        //}
        //public static Recommendation Create(GenreSearchResult authorSearchResult)
        //{
        //    return new Recommendation();
        //}
        //public static Recommendation Create(YearSearchResult authorSearchResult)
        //{
        //    return new Recommendation();
        //}
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
