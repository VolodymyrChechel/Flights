using System.Collections;
using System.Collections.Generic;
using Airline.BLL.DTO;

namespace Airline.BLL.Interfaces
{
    public interface IFlightParkService
    {
        IEnumerable<FlightParkDto> GetFlightParks();
        FlightParkDto GetFlightPark(object key);
    }
}