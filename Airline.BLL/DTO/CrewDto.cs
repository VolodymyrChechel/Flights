using System.Collections.Generic;
using Airline.DAL.Entities;

namespace Airline.BLL.DTO
{
    public class CrewDto
    {
        public int Id { get; set; }

        public int CrewCompositionCaptainAmount { get; set; }
        public int CrewCompositionAircraftPilotAmount { get; set; }
        public int CrewCompositionNavigatorOfficerAmount { get; set; }
        public int CrewCompositionRadioOperatorAmount { get; set; }
        public int CrewCompositionAirHostessNumber { get; set; }

        public int CrewCompositionId { get; set; } = 1;
        //public CrewComposition CrewComposition { get; set; }
        //public ICollection<Worker> Workers { get; set; }
        //public ICollection<Flight> Flights { get; set; }

    }
}