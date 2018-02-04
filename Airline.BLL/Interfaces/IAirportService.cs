using System.Collections;
using System.Collections.Generic;
using Airline.BLL.DTO;

namespace Airline.BLL.Interfaces
{
    public interface IAirportService
    {
        IEnumerable<AirportDto> GetAirports();
        AirportDto GetAirport(object key);
        void CreateAirport(AirportDto airportDto);
        void EditAirport(AirportDto airportDto);
        void DeleteAirport(object key);

    }
}