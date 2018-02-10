using System;
using System.Collections;
using System.Collections.Generic;

namespace Airline.DAL.Entities
{
    public class FlightPark
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartUsing { get; set; }

        public int? PlaneId { get; set; } 
        public Plane Plane { get; set; }

        public int? CrewCompositionId { get; set; }
        public CrewComposition CrewComposition { get; set; }

        public ICollection<Flight> Flights { get; set; }

    }
}