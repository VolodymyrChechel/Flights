using System.Collections.Generic;
using Airline.DAL.Entities;

namespace Airline.BLL.DTO
{
    /// <summary>
    /// Dto for crew composition model
    /// describe compostion of crew
    /// </summary>
    public class CrewCompostionDto
    {
        public int Id { get; set; }

        public int CaptainAmount { get; set; }
        public int AircraftPilotAmount { get; set; }
        public int NavigatorOfficerAmount { get; set; }
        public int RadioOperatorAmount { get; set; }
        public int AirHostessAmount { get; set; }

    }
}