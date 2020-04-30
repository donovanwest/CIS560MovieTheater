using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.Json.Serialization;
using DataAccess;
using Newtonsoft.Json;
using Microsoft.VisualBasic.FileIO;
using MovieTheaterData;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace DatabaseTest
{
    class Program
    {
        static string[] valid = { "G", "PG", "PG-13", "R", "NC-17", "Not Rated" };
        static void Main(string[] args)
        {
            
            Console.WriteLine("Start");
            ///ConnectionString
            string connectionString;
            ///ConnectionString Initializaion password hiding.
            {
                connectionString = "Server=mssql.cs.ksu.edu;Database=donovanwest;User Id=donovanwest;Password=Donnybob185;";
            }

            //LoadMovies(connectionString);
            //LoadTheaters(connectionString);
            //LoadEmployees(connectionString);

            IReadOnlyList<Movie> movies = GetMovies(connectionString);
            IReadOnlyList<Theater> theaters = GetTheaters(connectionString);
            IReadOnlyList<Employee> employees = GetEmployees(connectionString);

            LoadShowings(connectionString, movies, theaters, employees);
        }

        static void LoadMovies(string connectionString)
        {
            Console.WriteLine("Parsing JSON");
            var repo = new MovieRepo(connectionString);
            List<Movie> items;
            using (StreamReader r = new StreamReader("movies.json"))
            {
                string json = r.ReadToEnd();
                Console.WriteLine("JSON Read");
                items = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
            Console.WriteLine("inserting " + items.Count + " rows");
            foreach (Movie i in items)
            {
                if (!valid.Contains<string>(i.MPAA_Rating))
                    i.MPAA_Rating = "Not Rated";
                repo.SaveMovie(i.Title, i.Worldwide_Gross, i.Release_Date, i.MPAA_Rating, i.Rotten_Tomatoes_Rating, i.Director);
            }
            Console.WriteLine("inserted " + items.Count + " rows");
        }

        static void LoadTheaters(string connectionString)
        {
            Console.WriteLine("Parsing Theaters");
            List<Theater> theaters = new List<Theater>();
            using (TextFieldParser parser = new TextFieldParser("Theaters.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    Theater t = new Theater();
                    string[] fields = parser.ReadFields();
                    t.Capacity = Convert.ToInt32(fields[0]);
                    t.HandicapAccesible = Convert.ToBoolean(fields[1]);
                    t.DineIn = Convert.ToBoolean(fields[2]);
                    theaters.Add(t);
                }
            }
            Console.WriteLine("Inserting Theaters");
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("MovieTheater.CreateTheater", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        foreach (Theater t in theaters)
                        {
                            command.Parameters.AddWithValue("Capacity", t.Capacity);
                            command.Parameters.AddWithValue("HandicapAccessible", t.HandicapAccesible);
                            command.Parameters.AddWithValue("DineIn", t.DineIn);
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                        transaction.Complete();
                    }
                }
            }
        }

        static void LoadEmployees(string connectionString)
        {
            Console.WriteLine("Parsing Employees");
            List<Employee> employees = new List<Employee>();
            using (TextFieldParser parser = new TextFieldParser("Employees.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    Employee e = new Employee();
                    string[] fields = parser.ReadFields();
                    e.HourlyPay = Convert.ToDouble(fields[0]);
                    e.FirstName = fields[1];
                    e.LastName = fields[2];
                    e.HiredDate = Convert.ToDateTime(fields[3]); 
                    if(fields[4] != "")
                        e.TerminatedDate = Convert.ToDateTime(fields[4]);
                    int a = 0;
                    while(e.TerminatedDate != null && e.TerminatedDate < e.HiredDate)
                    {
                        e.TerminatedDate = e.HiredDate.AddDays(new Random().Next(5, 3000));
                        if (a > 10)
                            e.TerminatedDate = e.HiredDate.AddDays(5);
                    }                    
                    employees.Add(e);
                }
            }
            Console.WriteLine("Inserting Employees");
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("MovieTheater.CreateEmployee", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        foreach (Employee e in employees)
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("HourlyPay", e.HourlyPay);
                            command.Parameters.AddWithValue("FirstName", e.FirstName);
                            command.Parameters.AddWithValue("LastName", e.LastName);
                            command.Parameters.AddWithValue("HiredDate", e.HiredDate);
                            command.Parameters.AddWithValue("TerminatedDate", e.TerminatedDate);
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                        transaction.Complete();
                    }
                }
            }
        }

        static void LoadShowings(string connectionString, IReadOnlyList<Movie> movies, IReadOnlyList<Theater> theaters, IReadOnlyList<Employee> Employees)
        {
            Random r = new Random();
            Console.WriteLine("Loading Showings");
            List<Showing> showings = new List<Showing>();
            foreach(Movie m in movies)
            {
                int a = r.Next(8, 20);
                for(int k = 0; k<a; k++)
                {
                    Showing s = new Showing();
                    s.MovieID = m.MovieID;
                    Theater t = theaters.ElementAt<Theater>(r.Next(0, theaters.Count - 1));
                    s.TheaterID = t.TheaterID;
                    s.StartTime = Convert.ToDateTime(m.Release_Date).AddDays(r.Next(0,60)).AddHours(r.Next(0,24)).AddMinutes(r.Next(0,60));
                    s.EndTime = s.StartTime.AddMinutes(r.Next(60, 210));
                    s.TicketsPurchased = r.Next(0, t.Capacity);
                    s.TicketPrice = ((double)r.Next(400, 1500)) / 100;
                    showings.Add(s);
                }
            }
            Console.WriteLine("Showings created, sending them to database");
            foreach (Showing s in showings)
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new System.TimeSpan(2, 0, 0)))
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        using (var command = new SqlCommand("MovieTheater.CreateShowing", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            connection.Open();
                            //Console.WriteLine("Adding showing with movie" + s.MovieID);
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("MovieID", s.MovieID);
                            command.Parameters.AddWithValue("TheaterID", s.TheaterID);
                            command.Parameters.AddWithValue("StartTime", s.StartTime);
                            command.Parameters.AddWithValue("EndTime", s.EndTime);
                            command.Parameters.AddWithValue("TicketsPurchased", s.TicketsPurchased);
                            command.Parameters.AddWithValue("TicketPrice", s.TicketPrice);
                            var p = command.Parameters.Add("ShowingID", SqlDbType.Int);
                            p.Direction = ParameterDirection.Output;
                            command.ExecuteNonQuery();
                            s.ShowingID = (int)command.Parameters["ShowingID"].Value;
                        }
                        transaction.Complete();
                    }
                }
            }
            Console.WriteLine("Showings uploaded");
            Console.WriteLine("Loading EmployeeShowing");
            foreach(Showing s in showings)
            {
                List<Employee> validEmployees = new List<Employee>();
                foreach (Employee e in validEmployees)
                    if (e.HiredDate < s.StartTime && (e.TerminatedDate == null || e.TerminatedDate > s.StartTime))
                        validEmployees.Add(e);

                int g = r.Next(1, 3);
                if (validEmployees.Count < g)
                    g = validEmployees.Count;
                for (int c = 0; c < g; c++)
                    AddEmployeeShowing(s.ShowingID, validEmployees.ElementAt<Employee>(r.Next(0, validEmployees.Count)).EmployeeID, connectionString);
            }
            Console.WriteLine("EmployeeShowings loaded");
        }

        static void AddEmployeeShowing(int ShowingID, int EmployeeID, string connectionString)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("MovieTheater.CreateEmployeeShowing", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        command.Parameters.AddWithValue("EmployeeID", EmployeeID);
                        command.Parameters.AddWithValue("ShowingID", ShowingID);
                        command.ExecuteNonQuery();
                        transaction.Complete();
                    }
                }
            }
        }

        static IReadOnlyList<Movie> GetMovies(string connectionString)
        {
            Console.WriteLine("Getting Movies");
            List<Movie> movies = new List<Movie>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("MovieTheater.GetMovies", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            Movie m = new Movie();
                            m.MovieID = reader.GetInt32("MovieID");
                            m.Title = reader.GetString("Title");
                            if (!reader.IsDBNull("Director"))
                                m.Director = reader.GetString("Director");
                            m.MPAA_Rating = reader.GetString("MPAA_Rating");
                            if (!reader.IsDBNull("RottenTomatoesRating"))
                                m.Rotten_Tomatoes_Rating = reader.GetInt32("RottenTomatoesRating");
                            m.Release_Date = reader.GetDateTime("ReleaseDate").ToString();
                            if (!reader.IsDBNull("WorldwideGross"))
                                m.Worldwide_Gross = reader.GetInt64("WorldwideGross");
                            movies.Add(m);
                        }
                    }
                }
            }
            Console.WriteLine("Returning Movies");
            return movies;
        }

        static IReadOnlyList<Theater> GetTheaters(string connectionString)
        {
            Console.WriteLine("Getting Theaters");
            List<Theater> theaters = new List<Theater>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("MovieTheater.GetTheaters", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Theater t = new Theater();
                            t.TheaterID = reader.GetInt32("TheaterID");
                            t.Capacity = reader.GetInt32("Capacity");
                            t.HandicapAccesible = reader.GetBoolean("HandicapAccessible");
                            t.DineIn = reader.GetBoolean("DineIn");
                            theaters.Add(t);
                        }
                    }
                }
            }
            Console.WriteLine("returning Theaters");
            return theaters;
        }

        static IReadOnlyList<Employee> GetEmployees(string connectionString)
        {
            Console.WriteLine("Getting Employees");
            List<Employee> employees = new List<Employee>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("MovieTheater.GetEmployees", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee e = new Employee();
                            e.EmployeeID = reader.GetInt32("EmployeeID");
                            e.HourlyPay = reader.GetDouble("HourlyPay");
                            e.FirstName = reader.GetString("FirstName");
                            e.LastName = reader.GetString("LastName");
                            e.HiredDate = reader.GetDateTime("HiredDate");
                            if (!reader.IsDBNull("TerminatedDate"))
                                e.TerminatedDate = reader.GetDateTime("TerminatedDate");
                            employees.Add(e);
                        }
                    }
                }
            }
            Console.WriteLine("Returning Employees");
            return employees;
        }




    }
}
