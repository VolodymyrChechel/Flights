using System;
using System.Collections;
using System.Collections.Generic;
using Airline.BLL.DTO;

namespace Airline.BLL.Interfaces
{
    public interface IFlightService
    {
        IEnumerable<FlightDto> GetFlights();
        FlightDto GetFlight(object key);
        void CreateFlight(FlightDto flightDto);
        void EditFlight(FlightDto flightDto);
        void DeleteFlight(object key);

    }
}