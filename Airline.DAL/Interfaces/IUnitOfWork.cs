using System;
using Airline.DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Airline.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Worker> Workers { get; }
        IGenericRepository<Flight> Flights { get; }
        IGenericRepository<Airport> Airports { get; }
        IGenericRepository<Crew> Crews { get; }

        UserManager<IdentityUser> Users { get; }
        RoleManager<IdentityRole> Roles { get; }


        void Save();
    }
}