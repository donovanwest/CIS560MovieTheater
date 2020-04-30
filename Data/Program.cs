using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using MovieTheaterData;
using System.Data;
using System.Data.SqlClient;
using DatabaseTest;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic.FileIO;
using System.Transactions;

namespace DataAccessDemo.Data
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
            LoadEmployees(connectionString);
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
        
    }
}
