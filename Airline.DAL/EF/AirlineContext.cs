﻿using System.Data.Entity;
using Airline.DAL.Entities;

namespace Airline.DAL.EF
{
    public class AirlineContext : DbContext
    {
        static AirlineContext()
        {
            Database.SetInitializer<AirlineContext>(new AirlineDbInitializer());
        }

        public AirlineContext(string connectionString) : base(connectionString)
        {
            
        }

        public IDbSet<Airport> Airports { get; set; } // initialized
        public IDbSet<Flight> Flights { get; set; }
        public IDbSet<FlightPark> FlightParks { get; set; }
        public IDbSet<Worker> Workers { get; set; }
        public IDbSet<Plane> Planes { get; set; }
        
    }
}