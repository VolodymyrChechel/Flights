namespace Airline.WEB.Models
{
    public class SearchViewModel
    {
        public string SearchKeyword { get; set; }
        public string SortField { get; set; }
        public string PagingSize { get; set; }
        public int CurrentPage { get; set; }
    }
}