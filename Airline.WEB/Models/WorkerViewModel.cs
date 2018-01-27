using System;
using Airline.Common.Enums;

namespace Airline.WEB.Models
{
    public class WorkerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public CrewmanType CrewmanType { get; set; }

        //public ICollection<Crew> Crews { get; set; }
    }
}