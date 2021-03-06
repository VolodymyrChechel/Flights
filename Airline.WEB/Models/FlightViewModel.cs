﻿using System;
using System.ComponentModel.DataAnnotations;
using Airline.Common.Enums;
using Airline.Common.StaticData;
using Airline.WEB.Validators;
using Newtonsoft.Json;

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

        public string FromName { get; set; }
        public string ToName { get; set; }

        [Required]
        public string PlannedDepartureTime { get; set; } = "12:00 AM";

        [Required]
        [RegularExpression(ValidationRegex.Time, ErrorMessage = "Duration has no appropriate format XX:XX")]
        public string PlannedFlightTime { get; set; } = "1:00";
    }
}