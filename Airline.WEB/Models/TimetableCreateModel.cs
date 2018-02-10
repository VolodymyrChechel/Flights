using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Airline.Common.Enums;

namespace Airline.WEB.Models
{
    public class TimetableCreateModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public TimeSpan PlannedTime { get; set; }
        //public Crew Crew { get; set; }
        public int? CrewId { get; set; }
        public IEnumerable<SelectListItem> CrewSelectListItems { get; set; }

        //public Flight Flight { get; set; }
        public string FlightId { get; set; }
        public IEnumerable<SelectListItem> FlightSelectListItems { get; set; }
        
        //public FlightPark FlightPark { get; set; }
        public int? FlightParkId { get; set; }
        public IEnumerable<SelectListItem> FlightParkSelectListItems { get; set; }
    }
}