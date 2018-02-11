using System;
using Airline.Common.Enums;

namespace Airline.WEB.Models
{
    public class TimetableModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public TimeSpan PlannedTime { get; set; }
        public int? CrewId { get; set; }

        public string FlightId { get; set; }

        public string FlightFromIATA { get; set; }
        public string FlightFromName { get; set; }
        public string FlightToIATA { get; set; }
        public string FlightToName { get; set; }

        public int? FlightParkId { get; set; }
    }
}