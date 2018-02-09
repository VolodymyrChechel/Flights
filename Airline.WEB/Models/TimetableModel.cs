using System;
using Airline.Common.Enums;

namespace Airline.WEB.Models
{
    public class TimetableModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }

        //public Crew Crew { get; set; }
        public int? CrewId { get; set; }

        //public Flight Flight { get; set; }
        public string FlightId { get; set; }

        //public FlightPark FlightPark { get; set; }
        public int? FlightParkId { get; set; }
    }
}