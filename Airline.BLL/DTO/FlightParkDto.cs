using System;
using System.Collections;
using System.Collections.Generic;

namespace Airline.BLL.DTO
{
    public class FlightParkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int PlaneId { get; set; } 

        public int CrewCompositionId { get; set; }

    }
}