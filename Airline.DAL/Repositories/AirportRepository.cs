using Airline.DAL.EF;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;

namespace Airline.DAL.Repositories
{
    public class AirportRepository : GenericRepository<AirlineContext, Airport>
    {
        public AirportRepository(AirlineContext context) : base(context)
        {


        }
    }
}