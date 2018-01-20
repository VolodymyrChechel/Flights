using System.Collections;
using System.Collections.Generic;

namespace Airline.DAL.Entities
{
    // Represents plane entity
    public class Plane
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int NumberOfPilots { get; set; }
        public int NumberOfNavigatorOfficers { get; set; }
        public int NumberOfRadioOperators { get; set; }
        public int NumberOfAirHostesses { get; set; }
        
        public double Velocity { get; set; }
        public int Capacity { get; set; }

        public ICollection<FlightPark> FlightParks { get; set; }
    }
}