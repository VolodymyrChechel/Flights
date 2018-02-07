using System.Collections.Generic;

namespace Airline.DAL.Entities
{
    /// <summary>
    /// Entity is used for describe composition of aircrew.
    /// </summary>
    public class CrewComposition
    {
        public int Id { get; set; }

        public int CaptainAmount { get; set; }
        public int AircraftPilotAmount { get; set; }
        public int NavigatorOfficerAmount { get; set; }
        public int RadioOperatorAmount { get; set; }
        public int AirHostessNumber { get; set; }

        public ICollection<Crew> Crews { get; set; }

    }
}