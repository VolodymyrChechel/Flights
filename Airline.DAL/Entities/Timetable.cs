using System;

namespace Airline.DAL.Entities
{
    public class Timetable
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        public Crew Crew { get; set; }
        public int? CrewId { get; set; }

        public Flight Flight { get; set; }
        public string FlightId { get; set; }

        public FlightPark FlightPark { get; set; }
        public int? FlightParkId { get; set; }
    }
}