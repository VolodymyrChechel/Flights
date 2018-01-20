using System.ComponentModel.DataAnnotations;

namespace Airline.DAL.Entities
{
    public class Airport
    {
        [Key]
        public string IATA { get; set; }

        public string City { get; set; }
    }
}