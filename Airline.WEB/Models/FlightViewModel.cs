using System;
using System.ComponentModel.DataAnnotations;
using Airline.Common.Enums;
using Airline.Common.StaticData;
using Airline.WEB.Validators;

namespace Airline.WEB.Models
{
    public class FlightViewModel
    {
        public String Id { get; set; }

        public string FromIATA { get; set; }
        public string ToIATA { get; set; }
        [Required]
        public DateTime PlannedDepartureTime { get; set; }
        [Required]
        public TimeSpan PlannedFlightTime { get; set; }
    }
}