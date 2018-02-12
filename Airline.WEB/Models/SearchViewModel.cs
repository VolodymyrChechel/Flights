using System;
using System.ComponentModel.DataAnnotations;
using Airline.Common.Enums;

namespace Airline.WEB.Models
{
    public class SearchViewModel
    {
        [Display(Name = "Flight to search")]
        public string SearchKeyword { get; set; }

        public SelectionField Selection { get; set; }

        [Display(Name = "Keyword for searching")]
        public string SelectionKeyword { get; set; }
        public SortOptions SortField { get; set; }

        //public string PagingSize { get; set; }
        //public int CurrentPage { get; set; }
    }
}