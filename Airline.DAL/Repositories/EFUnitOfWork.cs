using System;
using Airline.DAL.EF;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;

namespace Airline.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private AirlineContext db;

        private WorkerRepository workerRepository;


        public EFUnitOfWork(string connectionString)
        {
            db = new AirlineContext(connectionString);
        }
        
        
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}