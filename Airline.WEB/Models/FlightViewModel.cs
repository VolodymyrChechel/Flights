using System;
using System.ComponentModel.DataAnnotations;
using Airline.Common.Enums;
using Airline.Common.StaticData;
using Airline.WEB.Validators;

namespace Airline.WEB.Models
{
    public class FlightViewModel
    {
        [Required]
        [RegularExpression(ValidationRegex.FlightNumber, ErrorMessage = "Fight's id must match a format - AB123")]
        public String Id { get; set; }

        [Required]
        public string FromIATA { get; set; }
        [Required]
        [NotEqual("FromIATA", ErrorMessage = "From and To IATA must not be equal")]
        public string ToIATA { get; set; }
        [Required]
        public DateTime PlannedDepartureTime { get; set; }
        [Required]
        [RegularExpression(ValidationRegex.Time, ErrorMessage = "Duration has no appropriate format XX:XX")]
        public string PlannedFlightTime { get; set; }
    }
}