using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public void GetLastFlightDataForFlightPark(object key, out DateTime date, out string airportId)
        {
            if (key == null)
                throw new ArgumentException("Flight park's id was not set");

            var flightPark = Database.FlightParks.GetAll().Where(x => x.Id == (int)key).Include(x => x.Timetables)
                .FirstOrDefault();

            if (flightPark == null)
                throw new ArgumentException("Flight park was not found");

            airportId = "";
            date = DateTime.UtcNow;
            try
            {
                var lastTimeTable = flightPark.Timetables.OrderByDescending(x => x.DateTime).First();
                airportId = Database.Flights.Get(lastTimeTable.FlightId).ToIATA;

                var crewDateTime = lastTimeTable.DateTime.AddDays(1);
                date = DateTime.UtcNow.AddDays(1);

                if (crewDateTime > date)
                    date = crewDateTime;
            }
            catch { }
        }
    }
}