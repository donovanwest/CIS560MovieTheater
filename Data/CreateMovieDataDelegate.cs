using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;
//using DataAccessDemmo.Data;
namespace DataAccessDemo.Data
{
    internal class CreateMovieDataDelegate : NonQueryDataDelegate<Movie>
    {
        public string Title;
        public Nullable<Int64> Worldwide_Gross;
        public string Release_Date;
        public string MPAA_Rating;
        public string Director;
        public Nullable<int> Rotten_Tomatoes_Rating;

        public CreateMovieDataDelegate(string title, Nullable<Int64> worldwide_Gross, string release_Date, string MPAA_Rating, Nullable<int> rotten_Tomatoes_Rating, string director) : base("MovieTheater.CreateMovie")
        {
            Title = title;
            Worldwide_Gross = worldwide_Gross;
            Release_Date = release_Date;
            this.MPAA_Rating = MPAA_Rating;
            Rotten_Tomatoes_Rating = rotten_Tomatoes_Rating;
            Director = director;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("Title", SqlDbType.NVarChar);
            p.Value = Title;

            p = command.Parameters.Add("WorldwideGross", SqlDbType.BigInt);
            if (Worldwide_Gross != null)
                p.Value = Convert.ToInt64(Worldwide_Gross);
            else
                p.Value = DBNull.Value;

            p = command.Parameters.Add("ReleaseDate", SqlDbType.Date);
            p.Value = Convert.ToDateTime(Release_Date);

            p = command.Parameters.Add("MPAA_Rating", SqlDbType.NVarChar);
            if(MPAA_Rating != null)
                p.Value = MPAA_Rating;
            else
                p.Value = DBNull.Value;

            p = command.Parameters.Add("RottenTomatoesRating", SqlDbType.Int);
            if (Rotten_Tomatoes_Rating != null)
                p.Value = Convert.ToInt16(Rotten_Tomatoes_Rating);
            else
                p.Value = DBNull.Value;

            p = command.Parameters.Add("Director", SqlDbType.NVarChar);
            if(Director != null)
                p.Value = Convert.ToString(Director);
            else
                p.Value = DBNull.Value;

            p = command.Parameters.Add("MovieID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Movie Translate(SqlCommand command)
        {
            return new Movie((int)command.Parameters["MovieID"].Value, Title, Worldwide_Gross, Release_Date, MPAA_Rating, Rotten_Tomatoes_Rating, Director);
        }
    }
}
