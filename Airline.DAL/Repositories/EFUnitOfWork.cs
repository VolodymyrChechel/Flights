using System;
using System.Data.Entity.Validation;
using Airline.DAL.EF;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Airline.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly AirlineContext _db;

        private WorkerRepository _workerRepository;
        private FlightRepository _flightRepository;
        private AirportRepository _airportRepository;
        private CrewRepository _crewRepository;
        private CrewCompositionRepositiory _crewCompositionRepositiory;
        private TimetableRepository _timetableRepository;

        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public EFUnitOfWork(string connectionString)
        {
            _db = new AirlineContext(connectionString);
        }
        
        public IGenericRepository<Worker> Workers
        {
            get
            {
                if(_workerRepository == null)
                    _workerRepository = new WorkerRepository(_db);

                return _workerRepository;
            }
        }

        public IGenericRepository<Flight> Flights
        {
            get
            {
                if (_flightRepository == null)
                    _flightRepository = new FlightRepository(_db);

                return _flightRepository;
            }
        }

        public IGenericRepository<Airport> Airports
        {
            get
            {
                if (_airportRepository == null)
                    _airportRepository = new AirportRepository(_db);

                return _airportRepository;
            }
        }

        public IGenericRepository<Crew> Crews
        {
            get
            {
                if (_crewRepository == null)
                    _crewRepository = new CrewRepository(_db);

                return _crewRepository;
            }
        }

        public IGenericRepository<Timetable> Timetables
        {
            get
            {
                if (_timetableRepository == null)
                    _timetableRepository = new TimetableRepository(_db);

                return _timetableRepository;
            }
        }

        public IGenericRepository<CrewComposition> CrewCompositions
        {
            get
            {
                if (_crewCompositionRepositiory == null)
                    _crewCompositionRepositiory = new CrewCompositionRepositiory(_db);

                return _crewCompositionRepositiory;
            }
        }

        public UserManager<IdentityUser> Users
        {
            get
            {
                if(_userManager == null)
                    _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_db));

                return _userManager;
            }
        }

        public RoleManager<IdentityRole> Roles
        {
            get
            {
                if (_roleManager == null)
                    _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_db));

                return _roleManager;
            }
        }

        public void Save()
        {
            try
            {
                _db.SaveChanges();
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
                    _db.Dispose();
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