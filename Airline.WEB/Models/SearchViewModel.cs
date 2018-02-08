using System;

namespace Airline.WEB.Models
{
    public class SearchViewModel
    {
        public string SearchKeyword { get; set; }
        public SelectionField Selection { get; set; }
        public string SelectionKeyword { get; set; }
        public SortOptions SortField { get; set; }

        //public string PagingSize { get; set; }
        //public int CurrentPage { get; set; }

        public enum SelectionField
        {
            DeparturePlace, ArrivingPlace, Date
        }

        public enum SortOptions
        {
            DescendByNumeber, AscendByNumber
        }
    }
}