using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.IO;
using System.Linq;

namespace DatabaseTest
{

    public class Movie
    {
        //static string[] valid = { "G", "PG", "PG-13", "R", "NC-17", "Not Rated" };
        public string Title { get; set; }
        public Nullable<Int64> Worldwide_Gross { get; set; }
        public string Release_Date { get; set; }
        public string MPAA_Rating { get; set; }
        public int MovieID { get; set; }
        /*
        public string MPAA_Rating
        {
            get { return MPAA_Rating; }
            set
            {
                MPAA_Rating = value;
                if (value == "G" || value == "PG" || value == "PG-13" || value == "R" || value == "NC-17" || value == "Not Rated")
                    MPAA_Rating = value;
                else
                    MPAA_Rating = "Not Rated";
            }
        }
            */
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
            // Convert.ToDateTime(release_Date);
        }
        public Movie() { }
    }
}
