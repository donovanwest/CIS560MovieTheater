using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.IO;
using System.Linq;

namespace DataAccessDemo.Data
{

    public class Movie
    {
        public string Title { get; set; }
        public Nullable<Int64> Worldwide_Gross { get; set; }
        public string Release_Date { get; set; }
        public string MPAA_Rating { get; set; }
        public int MovieID { get; set; }
        public Nullable<int> Rotten_Tomatoes_Rating { get; set; }
        public string Director { get; set; }


        public Movie(int MovieID, string title, Nullable<Int64> worldwide_Gross, string release_Date, string MPAA_Rating, Nullable<int> rotten_Tomatoes_Rating, string director)
        {
            Title = title;
            Worldwide_Gross = worldwide_Gross;
            Release_Date = release_Date;
            this.MPAA_Rating = MPAA_Rating;
            Rotten_Tomatoes_Rating = rotten_Tomatoes_Rating;
            Director = director;
        }
        public Movie() { }
    }
}
