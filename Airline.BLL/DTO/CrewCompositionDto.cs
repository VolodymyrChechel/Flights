using System.Collections.Generic;
using Airline.DAL.Entities;

namespace Airline.BLL.DTO
{
    public class CrewCompostionDto
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