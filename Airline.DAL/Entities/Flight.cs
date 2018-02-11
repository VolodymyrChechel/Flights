using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Airline.DAL.Entities
{
    /// <summary>
    /// Represents fligh table with destination, departure city, time and regularity
    /// </summary>
    public class Flight
    {
        [Key]
        public string Id { get; set; }
        public TimeSpan PlannedDepartureTime { get; set; }
        public TimeSpan PlannedFlightTime { get; set; }

        public string FromIATA { get; set; }
        public Airport From { get; set; }
        public string ToIATA { get; set; }
        public Airport To { get; set; }

        public Fl

        public ICollection<Timetable> Timetables { get; set; }
    }
}