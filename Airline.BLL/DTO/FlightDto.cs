﻿using System;
using Airline.DAL.Entities;

namespace Airline.BLL.DTO
{
    /// <summary>
    /// Represents fligh table with destination, departure city, time and regularity
    /// </summary>
    public class FlightDto
    {
        public string Id { get; set; }
        public TimeSpan PlannedDepartureTime { get; set; }
        public TimeSpan PlannedFlightTime { get; set; }

        public string FromIATA { get; set; }
        public string FromName { get; set; }
        //public Airport From { get; set; }
        public string ToIATA { get; set; }
        public string ToName { get; set; }
        //public Airport To { get; set; }
    }
}