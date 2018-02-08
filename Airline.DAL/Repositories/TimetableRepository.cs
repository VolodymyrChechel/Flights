using Airline.DAL.EF;
using Airline.DAL.Entities;

namespace Airline.DAL.Repositories
{
    public class TimetableRepository : GenericRepository<AirlineContext, Timetable>
    {
        public TimetableRepository(AirlineContext context) : base(context)
        {

        }
    }
}