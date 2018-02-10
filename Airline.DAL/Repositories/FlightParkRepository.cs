using Airline.DAL.EF;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;

namespace Airline.DAL.Repositories
{
    public class FlightParkRepository : GenericRepository<AirlineContext, FlightPark>
    {
        public FlightParkRepository(AirlineContext context) : base(context)
        {

        }
    }
}