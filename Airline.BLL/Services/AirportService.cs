using System;
using System.Collections.Generic;
using Airline.BLL.DTO;
using Airline.BLL.Infrastructure;
using Airline.BLL.Interfaces;
using Airline.BLL.Util;
using Airline.DAL.Entities;
using Airline.DAL.Interfaces;
using AutoMapper;

namespace Airline.BLL.Services
{
    public class AirportService : IAirportService
    {
        private IUnitOfWork Database { get; set; }

        public AirportService(IUnitOfWork uow)
        {
            Database = uow;
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.AddProfile(new BllMappingProfile());
            //});
        }

        public IEnumerable<AirportDto> GetAirports()
        {
            var airports = Database.Airports.GetAll();
            var airportDtos = Mapper.Map<IEnumerable<Airport>, IEnumerable<AirportDto>>(airports);
            return airportDtos;
        }

        public AirportDto GetAirport(object key)
        {
            if (key == null)
                throw new ArgumentException("Airport's id was not set");

            var airport = Database.Airports.Get(key);

            if (airport == null)
                throw new ArgumentException($"Airport with key={key} was not found");

            var airportDto = Mapper.Map<Airport, AirportDto>(airport);

            return airportDto;
        }

        public void CreateAirport(AirportDto airportDto)
        {
            if (airportDto == null)
                throw new ArgumentException("Airport's object was not passed");

            var airport = Mapper.Map<AirportDto, Airport>(airportDto);

            Database.Airports.Create(airport);
            Database.Save();
        }

        public void EditAirport(AirportDto airportDto)
        {
            if (airportDto == null)
                throw new ArgumentException("Aiport's object was not passed");

            var airport = Mapper.Map<AirportDto, Airport>(airportDto);

            Database.Airports.Update(airport);
            Database.Save();
        }

        public void DeleteAirport(object key)
        {
            if (key == null)
                throw new ArgumentException("Aiport's id was not set");

            Database.Airports.Delete(key);
            Database.Save();
        }
    }
}