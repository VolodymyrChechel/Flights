using System;
using Airline.Common.Enums;
using Airline.DAL.Entities;

namespace Airline.BLL.DTO
{
    /// <summary>
    /// Dto for timetable entity
    /// </summary>
    public class TimetableDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }

        public int? CrewId { get; set; }
        public string FlightId { get; set; }
        public int? FlightParkId { get; set; }

        public string FlightFromIATA { get; set; }
        public string FlightFromName { get; set; }
        public string FlightToIATA { get; set; }
        public string FlightToName { get; set; }
    }
}