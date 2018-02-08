using System.Collections.Generic;

namespace Airline.WEB.Models
{
    public class CrewCompostionViewModel
    {
        public int Id { get; set; }

        public int CaptainAmount { get; set; }
        public int AircraftPilotAmount { get; set; }
        public int NavigatorOfficerAmount { get; set; }
        public int RadioOperatorAmount { get; set; }
        public int AirHostessAmount { get; set; }

        //public CrewComposition CrewComposition { get; set; }
        //public ICollection<Worker> Workers { get; set; }
        //public ICollection<Flight> Flights { get; set; }

    }
}