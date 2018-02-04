using System;
using Airline.DAL.Entities;

namespace Airline.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Worker> Workers { get; }
        IGenericRepository<Flight> Flights { get; }
        IGenericRepository<Airport> Airports { get; }

        void Save();
    }
}