using Airline.DAL.EF;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;

namespace Airline.DAL.Repositories
{
    public class CrewRepository : GenericRepository<AirlineContext, Crew>
    {
        public CrewRepository(AirlineContext context) : base(context)
        {
            
        }
    }
}