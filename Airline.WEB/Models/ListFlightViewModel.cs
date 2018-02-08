using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Airline.Common.Enums;
using Airline.Common.StaticData;
using Airline.WEB.Validators;

namespace Airline.WEB.Models
{
    public class ListFlightViewModel
    {
        public IEnumerable<FlightViewModel> FlightsList { get; set; }

        public SearchViewModel SearchModel { get; set; }
    }
}