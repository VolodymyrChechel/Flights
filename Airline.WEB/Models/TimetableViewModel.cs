using System.Collections.Generic;

namespace Airline.WEB.Models
{
    public class TimetableViewModel
    {
        public IEnumerable<TimetableModel> TimetableList { get; set; }
        public SearchViewModel SearchModel { get; set; }
    }
}