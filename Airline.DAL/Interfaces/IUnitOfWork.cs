using System;
using Airline.DAL.Entities;

namespace Airline.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Worker> Workers { get; }

        void Save();
    }
}