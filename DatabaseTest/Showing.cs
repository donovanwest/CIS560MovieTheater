using System;
using System.Collections.Generic;
using System.Text;

namespace MovieTheaterData
{
    public class Showing
    {
        public int ShowingID {get;set;}
        public int MovieID { get; set; }
        public int TheaterID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TicketsPurchased { get; set; }
        public double TicketPrice { get; set; }
    }
}
