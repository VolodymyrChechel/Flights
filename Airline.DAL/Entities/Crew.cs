using System.Collections.Generic;

namespace Airline.DAL.Entities
{
    public class Crew
    {
        public int Id { get; set; }

        public ICollection<Worker> Workers { get; set; }
        public int CrewCompositionId { get; set; }
        public CrewComposition CrewComposition{ get; set; }
        public ICollection<Timetable> TimeTables { get; set; }

    }
}