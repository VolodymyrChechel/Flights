using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Airline.DAL.Entities
{
    public class Voyage
    {
        [Key]
        public string Id { get; set; }
        public Airport From { get; set; }
        public Airport To { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public ICollection<Crew> Crews { get; set; }
    }
}