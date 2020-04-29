using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text.Json.Serialization;
using DataAccess;
using Newtonsoft.Json;

namespace DatabaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ///ConnectionString
            string connectionString;
            ///ConnectionString Initializaion password hiding.
            {
                connectionString = "Server=mssql.cs.ksu.edu;Database=donovanwest;User Id=donovanwest;Password=Donnybob185;";
            }

            //var test = new SqlCommandExecutor(connectionString);
            var repo = new MovieRepo(connectionString);
            List<Movie> items;
            using (StreamReader r = new StreamReader("movies.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Movie>>(json);        
            }

            foreach(Movie i in items)
            {
                repo.SaveMovie(i.Title, i.Worldwide_Gross, i.Release_Date, i.MPAA_Rating, i.Rotten_Tomatoes_Rating, i.Director);
            }
        }
    }
    /*
    public class JSONClass
    {
        public string Title { get; set; }
        
        public Nullable<Int64> Worldwide_Gross { get; set; }
        public string Release_Date { get; set; }
        public string MPAA_Rating { get; set; }
        public string Director { get; set; }
        public Nullable<Int64> Rotten_Tomatoes_Rating { get; set; }
        */

    
}
