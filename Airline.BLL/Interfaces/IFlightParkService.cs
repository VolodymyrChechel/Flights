using System;
using System.Collections;
using System.Collections.Generic;
using Airline.BLL.DTO;

namespace Airline.BLL.Interfaces
{
    /// <summary>
    /// Service for flight park entity
    /// </summary>
    public interface IFlightParkService
    {
        IEnumerable<FlightParkDto> GetFlightParks();
        FlightParkDto GetFlightPark(object key);

        /// <summary>
        /// Allow get data of plane accessibility (date and airport)
        /// </summary>
        GetLastFlightDataForCrew(object key, out DateTime date, out string airportId);
    }
}