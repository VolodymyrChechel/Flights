using Airline.DAL.EF;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;

namespace Airline.DAL.Repositories
{
    public class CrewCompositionRepositiory : GenericRepository<AirlineContext, CrewComposition>
    {
        public CrewCompositionRepositiory(AirlineContext context) : base(context)
        {


        }
    }
}