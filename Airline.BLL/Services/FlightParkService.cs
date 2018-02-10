using System.Collections.Generic;
using Airline.BLL.DTO;
using Airline.BLL.Interfaces;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;
using AutoMapper;

namespace Airline.BLL.Services
{
    public class FlightParkService : IFlightParkService
    {
        private IUnitOfWork Database { get; set; }

        public FlightParkService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<FlightParkDto> GetFlightParks()
        {
            var parks = Database.FlightParks.GetAll();
            var parkDtos = Mapper.Map<IEnumerable<FlightPark>, IEnumerable<FlightParkDto>>(parks);
            return parkDtos;
        }
    }
}