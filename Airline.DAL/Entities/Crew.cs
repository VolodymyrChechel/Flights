using System.Collections.Generic;

namespace Airline.DAL.Entities
{
    public class Crew
    {
        public int Id { get; set; }

        public ICollection<Worker> Workers { get; set; }
        public ICollection<Flight> Flights { get; set; }

    }
}