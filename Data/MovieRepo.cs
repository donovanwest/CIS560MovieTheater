using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using System.Numerics;

namespace DatabaseTest
{
    public class MovieRepo
    {
        private readonly SqlCommandExecutor executor;

        public MovieRepo(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public void SaveMovie(string title, Nullable<Int64> worldwide_Gross, string release_Date, string MPAA_Rating, Nullable<int> rotten_Tomatoes_Rating, string director)
        {
            var d = new CreateMovieDataDelegate(title, worldwide_Gross, release_Date, MPAA_Rating, rotten_Tomatoes_Rating, director);
            executor.ExecuteNonQuery(d);
        }    
    }
}
