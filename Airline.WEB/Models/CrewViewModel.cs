using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Airline.Common.Enums;
using Airline.Common.StaticData;
using Airline.WEB.Validators;

namespace Airline.WEB.Models
{
    public class CrewViewModel
    {
        public int Id { get; set; }

        public int CrewCompositionCaptainAmount { get; set; }
        public int CrewCompositionAircraftPilotAmount { get; set; }
        public int CrewCompositionNavigatorOfficerAmount { get; set; }
        public int CrewCompositionRadioOperatorAmount { get; set; }
        public int CrewCompositionAirHostessNumber { get; set; }

        public IEnumerable<SelectListItem> CompositionSelectList { get; set; }
        public int CrewCompositionId { get; set; }

        public IEnumerable<SelectListItem> CaptainSelectList { get; set; }
        public IEnumerable<int> SelectedCaptains { get; set; }

        public IEnumerable<SelectListItem> AircraftPilotSelectList { get; set; }
        public IEnumerable<int> SelectedAircraftPilots { get; set; }

        public IEnumerable<SelectListItem> NavigatorOfficerSelectList { get; set; }
        public IEnumerable<int> SelectedNavigatorOfficers { get; set; }

        public IEnumerable<SelectListItem> RadioOperatorSelectList { get; set; }
        public IEnumerable<int> SelectedRadioOperators { get; set; }
        
        public IEnumerable<SelectListItem> AirHostessSelectList { get; set; }
        public IEnumerable<int> SelectedHostess { get; set; }

    }
}