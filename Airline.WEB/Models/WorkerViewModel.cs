using System;
using System.ComponentModel.DataAnnotations;
using Airline.Common.Enums;
using Airline.Common.StaticData;
using Airline.WEB.Validators;

namespace Airline.WEB.Models
{
    public class WorkerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Worker must have a name")]
        [RegularExpression(ValidationRegex.Name,
            ErrorMessage = "Name does not match the formatting")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Worker must have a surname")]
        [RegularExpression(ValidationRegex.Name,
            ErrorMessage = "Surname does not match the formatting")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DateRange("01/01/1950", "01/01/1999")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Input worker's phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(ValidationRegex.Phone,
            ErrorMessage = "Phone not match the formatting: +380XXXXXXXXXX")]
        public string PhoneNumber { get; set; }

        [Required]
        public CrewmanType CrewmanType { get; set; }

        //public ICollection<Crew> Crews { get; set; }
    }
}