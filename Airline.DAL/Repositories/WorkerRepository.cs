using Airline.DAL.EF;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;

namespace Airline.DAL.Repositories
{
    public class WorkerRepository : GenericRepository<AirlineContext, Worker>
    {
        public WorkerRepository(AirlineContext context) : base(context)
        {
            
        }
    }
}