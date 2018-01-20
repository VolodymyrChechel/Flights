using System;
using System.Collections;
using System.Collections.Generic;

namespace Airline.DAL.Entities
{
    public class FlightPark
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartUsing { get; set; }
        public Plane Planes { get; set; }

        
    }
}