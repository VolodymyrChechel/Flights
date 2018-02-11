using System;
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

        public FlightParkDto GetFlightPark(object key)
        {
            if (key == null)
                throw new ArgumentException("Flight park's id was not set");

            var park = Database.FlightParks.Get(key);

            if (park == null)
                throw new ArgumentException($"Flight park with key={key} was not found");

            var parkDto = Mapper.Map<FlightPark, FlightParkDto>(park);

            return parkDto;
        }
    }
}