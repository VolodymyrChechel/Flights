using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace Airline.WEB.Validators
{
    public class DateRangeAttribute : ValidationAttribute, IClientValidatable
    {
        private const string DateFromat = "MM/dd/yyyy";
        private const string DefaultErrorMessage = "'{0}' must be a date between {1:d} and {2:d}.";

        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }

        public DateRangeAttribute(string minDate, string maxDate) :
            base(DefaultErrorMessage)
        {
            MinDate = ParseDate(minDate);
            MaxDate = ParseDate(maxDate);
        }

        public override bool IsValid(object value)
        {
            if (value == null | !(value is DateTime))
                return true;

            DateTime dateValue = (DateTime) value;
            return MinDate <= dateValue & dateValue <= MaxDate;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, MinDate, MaxDate);
        }

        private static DateTime ParseDate(string date)
        {
            return DateTime.ParseExact(date, DateFromat, CultureInfo.InvariantCulture);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new[]
            {
                new ModelClientValidationRangeDateRule(FormatErrorMessage(metadata.GetDisplayName()), MinDate, MaxDate)
            };
        }
    }
}