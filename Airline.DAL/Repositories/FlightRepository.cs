using Airline.DAL.EF;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;

namespace Airline.DAL.Repositories
{
    public class FlightRepository : GenericRepository<AirlineContext, Worker>
    {
        public FlightRepository(AirlineContext context) : base(context)
        {
            
        }
    }
}