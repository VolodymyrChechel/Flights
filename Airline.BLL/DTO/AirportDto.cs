using System;
using Airline.DAL.Entities;

namespace Airline.BLL.DTO
{
    /// <summary>
    /// Represents fligh table with destination, departure city, time and regularity
    /// </summary>
    public class AirportDto
    {
        public string IATA { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}