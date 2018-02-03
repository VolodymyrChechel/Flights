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

        public string FromName { get; set; }
        public string ToName { get; set; }
        [Required]
        public TimeSpan PlannedDepartureTime { get; set; }
        [Required]
        public TimeSpan PlannedFlightTime { get; set; }
    }
}