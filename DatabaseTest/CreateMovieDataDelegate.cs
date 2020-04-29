using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;
namespace DatabaseTest
{
    internal class CreateMovieDataDelegate : NonQueryDataDelegate<Movie>
    {
        public string Title;
        public Nullable<BigInteger> Worldwide_Gross;
        public string Release_Date;
        public string MPAA_Rating;
        public string Director;
        public Nullable<int> Rotten_Tomatoes_Rating;

        public CreateMovieDataDelegate(string title, Nullable<BigInteger> worldwide_Gross, string release_Date, string MPAA_Rating, Nullable<int> rotten_Tomatoes_Rating, string director) : base("Movie.CreateMovie")
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

            p = command.Parameters.Add("Wordlwide_Gross", SqlDbType.BigInt);
            p.Value = Title;

            p = command.Parameters.Add("Release_Date", SqlDbType.Date);
            p.Value = Title;

            p = command.Parameters.Add("MPAA_Rating", SqlDbType.NVarChar);
            p.Value = Title;

            p = command.Parameters.Add("Rotten_Tomatoes_Rating", SqlDbType.Int);
            p.Value = Title;

            p = command.Parameters.Add("Director", SqlDbType.NVarChar);
            p.Value = Title;

            p = command.Parameters.Add("MovieID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Movie Translate(SqlCommand command)
        {
            return new Movie((int)command.Parameters["MovieID"].Value, Title, Worldwide_Gross, Release_Date, MPAA_Rating, Rotten_Tomatoes_Rating, Director);
        }
    }
}
