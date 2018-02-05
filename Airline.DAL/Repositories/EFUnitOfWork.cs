using System;
using System.Data.Entity.Validation;
using Airline.DAL.EF;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;

namespace Airline.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private AirlineContext db;

        private WorkerRepository workerRepository;
        private FlightRepository flightRepository;
        private AirportRepository airportRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new AirlineContext(connectionString);
        }
        
        public IGenericRepository<Worker> Workers
        {
            get
            {
                if(workerRepository == null)
                    workerRepository = new WorkerRepository(db);

                return workerRepository;
            }
        }

        public IGenericRepository<Flight> Flights
        {
            get
            {
                if (flightRepository == null)
                    flightRepository = new FlightRepository(db);

                return flightRepository;
            }
        }

        public IGenericRepository<Airport> Airports
        {
            get
            {
                if (airportRepository == null)
                    airportRepository = new AirportRepository(db);

                return airportRepository;
            }
        }

        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            
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