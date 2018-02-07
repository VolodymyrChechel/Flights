using System;
using System.Collections.Generic;
using System.Linq;
using Airline.BLL.DTO;
using Airline.BLL.Infrastructure;
using Airline.BLL.Interfaces;
using Airline.BLL.Util;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;
using AutoMapper;

namespace Airline.BLL.Services
{
    public class FlightService : IFlightService
    {
        private IUnitOfWork Database { get; set; }

        public FlightService(IUnitOfWork uow)
        {
            Database = uow;
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.AddProfile(new BllMappingProfile());
            //});
        }

        public IEnumerable<FlightDto> GetFlights()
        {
            var flights = Database.Flights.GetAll().ToList();
            var flightDtos = Mapper.Map<IEnumerable<Flight>, IEnumerable<FlightDto>>(flights);
            return flightDtos;
        }

        public FlightDto GetFlight(object key)
        {
            if (key == null)
                throw new ArgumentException("Flight's id was not set");

            var flight = Database.Flights.Get(key);

            if (flight == null)
                throw new ArgumentException($"Flight with key={key} was not found");

            var flightDto = Mapper.Map<Flight, FlightDto>(flight);

            return flightDto;
        }

        public void CreateFlight(FlightDto flightDto)
        {
            if (flightDto == null)
                throw new ArgumentException("Flight's object was not passed");
            
            var flight = Mapper.Map<FlightDto, Flight>(flightDto);

            Database.Flights.Create(flight);
            Database.Save();
        }

        public void EditFlight(FlightDto flightDto)
        {
            if (flightDto == null)
                throw new ArgumentException("Flight's object was not passed");

            var flight = Mapper.Map<FlightDto, Flight>(flightDto);

            Database.Flights.Update(flight);
            Database.Save();
        }

        public void DeleteFlight(object key)
        {
            if (key == null)
                throw new ArgumentException("Flight's id was not set");

            Database.Flights.Delete(key);
            Database.Save();
        }
    }
}