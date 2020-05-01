using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace DataAccessDemo.Data
{
    public static class Queries
    {
        //DONE
        public static IReadOnlyList<String> SearchForMovieByTitle(string connectionString, string title)
        {
            List<String> items = new List<string>();
            items.Add("MovieID|Title|Director|MPAA_Rating|RottenTomatoesRating|ReleaseDate|WorldwideGross");
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("MovieTheater.SearchForMovieByTitle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Title", title);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            string i = "";
                            var ordinal = reader.GetOrdinal("MovieID");
                            i += reader.GetInt32(ordinal) + "|";
                            ordinal = reader.GetOrdinal("Title");
                            i += reader.GetString(ordinal) + "|";
                            ordinal = reader.GetOrdinal("Director");
                            if (!reader.IsDBNull(ordinal))
                                i += reader.GetString(ordinal) + "|";
                            else i += "|";
                            ordinal = reader.GetOrdinal("MPAA_Rating");
                            i += reader.GetString(ordinal) + "|";
                            ordinal = reader.GetOrdinal("RottenTomatoesRating");
                            if (!reader.IsDBNull(ordinal))
                                i += reader.GetInt32(ordinal) + "|";
                            else i += "|";
                            ordinal = reader.GetOrdinal("ReleaseDate");
                            i += reader.GetDateTime(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("WorldwideGross");
                            if (!reader.IsDBNull(ordinal))
                                i += reader.GetInt64(ordinal);
                            items.Add(i);
                        }
                    }
                }
            }
            return items;
        }
        //DONE
        public static IReadOnlyList<String> SearchForEmployeeByName(string connectionString, string firstName, string lastName)
        {
            List<String> items = new List<string>();
            items.Add("EmployeeID|HourlyPay|FirstName|Lastname|HiredDate|TerminatedDate");
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("MovieTheater.SearchForEmployeeByName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("FirstName", firstName);
                    command.Parameters.AddWithValue("LastName", lastName);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            string i = "";
                            var ordinal = reader.GetOrdinal("EmployeeID");
                            i += reader.GetInt32(ordinal) + "|";
                            ordinal = reader.GetOrdinal("HourlyPay");
                            i += reader.GetDouble(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("FirstName");
                            if (!reader.IsDBNull(ordinal))
                                i += reader.GetString(ordinal) + "|";
                            else i += "|";
                            ordinal = reader.GetOrdinal("LastName");
                            i += reader.GetString(ordinal) + "|";
                            ordinal = reader.GetOrdinal("TerminatedDate");
                            if (!reader.IsDBNull(ordinal))
                                i += reader.GetDateTime(ordinal) + "|";
                            else i += "|";
                            ordinal = reader.GetOrdinal("HiredDate");
                            i += reader.GetDateTime(ordinal).ToString();
                            items.Add(i);
                        }
                    }
                }
            }
            return items;
        }
        //DONE
        public static IReadOnlyList<String> SearchForTheaterByID(string connectionString, int theaterID)
        {
            List<String> items = new List<string>();
            items.Add("TheaterID|Capacity|HandicapAccessible|DineIn");
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("MovieTheater.SearchForTheaterByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("TheaterID", theaterID);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            string i = "";
                            var ordinal = reader.GetOrdinal("TheaterID");
                            i += reader.GetInt32(ordinal) + "|";
                            ordinal = reader.GetOrdinal("Capacity");
                            i += reader.GetInt32(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("HandicapAccessible");
                            i += reader.GetBoolean(ordinal) + "|";
                            ordinal = reader.GetOrdinal("DineIn");
                            i += reader.GetBoolean(ordinal);
                            items.Add(i);
                        }
                    }
                }
            }
            return items;
        }
        //DONE
        public static IReadOnlyList<String> SearchForShowingsByTitle(string connectionString, string title)
        {
            List<String> items = new List<string>();
            items.Add("ShowingID|MovieID|TheaterID|StartTime|EndTime|TicketsPurchased|TicketPrice");
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("MovieTheater.SearchForShowingsByTitle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Title", title);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            string i = "";
                            var ordinal = reader.GetOrdinal("ShowingID");
                            i += reader.GetInt32(ordinal) + "|";
                            ordinal = reader.GetOrdinal("MovieID");
                            i += reader.GetInt32(ordinal) + "|";
                            ordinal = reader.GetOrdinal("TheaterID");
                            i += reader.GetInt32(ordinal) + "|";
                            ordinal = reader.GetOrdinal("StartTime");
                            i += reader.GetDateTimeOffset(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("EndTime");
                            i += reader.GetDateTimeOffset(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("TicketsPurchased");
                            i += reader.GetInt32(ordinal) + "|";
                            ordinal = reader.GetOrdinal("TicketPrice");
                            i += reader.GetDouble(ordinal).ToString();
                            items.Add(i);
                        }
                    }
                }
            }
            return items;
        }
        //DONE
        public static IReadOnlyList<String> TopTenRatedMovies(string connectionString)
        {
            List<String> items = new List<string>();
            items.Add("Title|RottenTomatoesRating|ReleaseDate|Director|WorldwideGross");
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("MovieTheater.TopTenRatedMovies", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string i = "";
                            var ordinal = reader.GetOrdinal("Title");
                            i += reader.GetString(ordinal) + "|";
                            ordinal = reader.GetOrdinal("RottenTomatoesRating");
                            i += reader.GetInt32(ordinal) + "|";
                            ordinal = reader.GetOrdinal("ReleaseDate");
                            i += reader.GetDateTime(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("Director");
                            if (!reader.IsDBNull(ordinal))
                                i += reader.GetString(ordinal).ToString() + "|";
                            else i += "|";
                            ordinal = reader.GetOrdinal("WorldwideGross");
                            i += reader.GetInt64(ordinal).ToString();
                            items.Add(i);
                        }
                    }
                }
            }
            return items;
        }
        //DONE
        public static IReadOnlyList<String> HighestGrossingShows(string connectionString)
        {
            List<String> items = new List<string>();
            items.Add("Title|StartTime|TicketsPurchased|TicketPrice|GrossProfit|LaborCost|TotalProfit");
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("MovieTheater.HighestGrossingShows", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string i = "";
                            var ordinal = reader.GetOrdinal("Title");
                            i += reader.GetString(ordinal) + "|";
                            ordinal = reader.GetOrdinal("StartTime");
                            i += reader.GetDateTimeOffset(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("TicketsPurchased");
                            i += reader.GetInt32(ordinal) + "|";
                            ordinal = reader.GetOrdinal("TicketPrice");
                            i += reader.GetDouble(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("GrossProfit");
                            i += reader.GetDouble(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("LaborCost");
                            i += reader.GetDouble(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("TotalProfit");
                            i += reader.GetDouble(ordinal).ToString();
                            items.Add(i);
                        }
                    }
                }
            }
            return items;
        }
        //DONE
        public static IReadOnlyList<String> HighestPaidEmployees(string connectionString)
        {
            List<String> items = new List<string>();
            items.Add("FirstName|LastName|HourlyPay|HiredDate|TerminatedDate");
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("MovieTheater.HighestPaidEmployees", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string i = "";
                            var ordinal = reader.GetOrdinal("FirstName");
                            i += reader.GetString(ordinal) + "|";
                            ordinal = reader.GetOrdinal("LastName");
                            i += reader.GetString(ordinal) + "|";
                            ordinal = reader.GetOrdinal("HourlyPay");
                            i += reader.GetDouble(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("HiredDate");
                            i += reader.GetDateTime(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("TerminatedDate");
                            if (!reader.IsDBNull(ordinal))
                                i += reader.GetDateTime(ordinal).ToString();

                            items.Add(i);
                        }
                    }
                }
            }
            return items;
        }
        //DONE
        public static IReadOnlyList<String> TheaterAmmenities(string connectionString)
        {
            List<String> items = new List<string>();
            items.Add("TheaterID|Capacity|HandicapAccessible|DineIn");
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("MovieTheater.TheaterAmmenities", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string i = "";
                            var ordinal = reader.GetOrdinal("TheaterID");
                            i += reader.GetInt32(ordinal) + "|";
                            ordinal = reader.GetOrdinal("Capacity");
                            i += reader.GetInt32(ordinal) + "|";
                            ordinal = reader.GetOrdinal("HandicapAccessible");
                            i += reader.GetBoolean(ordinal) + "|";
                            ordinal = reader.GetOrdinal("DineIn");
                            i += reader.GetBoolean(ordinal);
                            items.Add(i);
                        }
                    }
                }
            }
            return items;
        }
        //DONE
        public static IReadOnlyList<String> OldestMovies(string connectionString)
        {
            List<String> items = new List<string>();
            items.Add("Title|ReleaseDate|FirstShowing");
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("MovieTheater.OldestMovies", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string i = "";
                            var ordinal = reader.GetOrdinal("Title");
                            i += reader.GetString(ordinal) + "|";
                            ordinal = reader.GetOrdinal("ReleaseDate");
                            i += reader.GetDateTime(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("FirstShowing");
                            i += reader.GetDateTimeOffset(ordinal).ToString();
                            items.Add(i);
                        }
                    }
                }
            }
            return items;
        }
        //DONE
        public static IReadOnlyList<String> RecentMovies(string connectionString)
        {
            List<String> items = new List<string>();
            items.Add("Title|StartTime|TheaterID|TicketsAvailiable");
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("MovieTheater.RecentMovies", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string i = "";
                            var ordinal = reader.GetOrdinal("Title");
                            i += reader.GetString(ordinal) + "|";
                            ordinal = reader.GetOrdinal("StartTime");
                            i += reader.GetDateTimeOffset(ordinal) + "|";
                            ordinal = reader.GetOrdinal("TheaterID");
                            i += reader.GetInt32(ordinal) + "|";
                            ordinal = reader.GetOrdinal("TicketsAvailiable");
                            i += reader.GetInt32(ordinal);
                            items.Add(i);
                        }
                    }
                }
            }
            return items;
        }
        //DONE
        public static IReadOnlyList<String> MostProfitableMovies(string connectionString)
        {
            List<String> items = new List<string>();
            items.Add("Title|ReleaseDate|LocalGross|WorldwideGross|PercentageOfWorldWideSales");
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("MovieTheater.MostProfitableMovies", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string i = "";
                            var ordinal = reader.GetOrdinal("Title");
                            i += reader.GetString(ordinal) + "|";
                            ordinal = reader.GetOrdinal("ReleaseDate");
                            i += reader.GetDateTime(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("LocalGross");
                            i += reader.GetDouble(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("WorldwideGross");
                            if (!reader.IsDBNull(ordinal))
                                i += reader.GetInt64(ordinal).ToString() + "|";
                            else i += "|";
                            ordinal = reader.GetOrdinal("PercentageOfWorldWideSales");
                            if (!reader.IsDBNull(ordinal))
                                i += reader.GetDouble(ordinal).ToString();

                            items.Add(i);
                        }
                    }
                }
            }
            return items;
        }
        //DONE
        public static IReadOnlyList<String> MostPaidEmployees(string connectionString)
        {
            List<String> items = new List<string>();
            items.Add("FirstName|LastName|HourlyPay|HiredDate|TotalHoursWorked|TotalPay");
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("MovieTheater.MostPaidEmployees", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string i = "";
                            var ordinal = reader.GetOrdinal("FirstName");
                            i += reader.GetString(ordinal) + "|";
                            ordinal = reader.GetOrdinal("LastName");
                            i += reader.GetString(ordinal) + "|";
                            ordinal = reader.GetOrdinal("HourlyPay");
                            i += reader.GetDouble(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("hiredDate");
                            i += reader.GetDateTime(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("TotalHoursWorked");
                            i += reader.GetInt32(ordinal);
                            ordinal = reader.GetOrdinal("TotalPay");
                            i += reader.GetDouble(ordinal).ToString();
                            items.Add(i);
                        }
                    }
                }
            }
            return items;
        }
        //DONE
        public static IReadOnlyList<String> MostShowingsPerDirector(string connectionString)
        {
            List<String> items = new List<string>();
            items.Add("Director|TotalMovies|TotalShowings|GrossProfits");
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("MovieTheater.MostShowingsPerDirector", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string i = "";
                            var ordinal = reader.GetOrdinal("Director");
                            i += reader.GetString(ordinal) + "|";
                            ordinal = reader.GetOrdinal("TotalMovies");
                            i += reader.GetInt32(ordinal) + "|";
                            ordinal = reader.GetOrdinal("TotalShowings");
                            i += reader.GetInt32(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("GrossProfits");
                            i += reader.GetDouble(ordinal).ToString();
                            items.Add(i);
                        }
                    }
                }
            }
            return items;
        }
        //DONE
        public static IReadOnlyList<String> ProfitLostFromEmptySeats(string connectionString)
        {
            List<String> items = new List<string>();
            items.Add("TotalMoneyLostFromEmptySeats|AverageEmptySeatsPerShowing|AverageMoneyLostPerShowing");
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("MovieTheater.ProfitLostFromEmptySeats", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string i = "";
                            var ordinal = reader.GetOrdinal("TotalMoneyLostFromEmptySeats");
                            i += reader.GetDouble(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("AverageEmptySeatsPerShowing");
                            i += reader.GetInt32(ordinal).ToString() + "|";
                            ordinal = reader.GetOrdinal("AverageMoneyLostPerShowing");
                            i += reader.GetDouble(ordinal).ToString();
                            items.Add(i);
                        }
                    }
                }
            }
            return items;
        }

        public static void InsertEmployee(string connectionString, double hourlyPay, string firstName, string lastName, DateTime hiredDate)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("MovieTheater.CreateNewEmployee", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("HourlyPay", hourlyPay);
                        command.Parameters.AddWithValue("FirstName", firstName);
                        command.Parameters.AddWithValue("LastName", lastName);
                        command.Parameters.AddWithValue("HiredDate", hiredDate);
                        //command.Parameters.AddWithValue("TerminatedDate", null);
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                        transaction.Complete();
                    }
                }
            }
        }

        public static void InsertShowing(string connectionString, int employeeID, int theaterID, int movieID, DateTime startTime, DateTime endTime, int ticketsPurchased, double ticketPrice)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("MovieTheater.CreateNewShowing", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("MovieID", movieID);
                        command.Parameters.AddWithValue("StartTime", startTime);
                        command.Parameters.AddWithValue("EndTime", endTime);
                        command.Parameters.AddWithValue("TicketsPurchased", ticketsPurchased);
                        command.Parameters.AddWithValue("TicketPrice", ticketPrice);
                        command.Parameters.AddWithValue("TheaterID", theaterID);
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                        transaction.Complete();
                    }
                }
            }
        }
    }
}
