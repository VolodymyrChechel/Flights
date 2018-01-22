using Airline.DAL.EF;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;

namespace Airline.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private AirlineContext db;

        public EFUnitOfWork(string connectionString)
        {
            db = new AirlineContext(connectionString);
        }
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        

        public IGenericRepository<Worker> Workers { get; }
        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}