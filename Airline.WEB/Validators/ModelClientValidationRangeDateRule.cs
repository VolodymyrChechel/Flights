using System;
using System.Web.Mvc;

namespace Airline.WEB.Validators
{
    public class ModelClientValidationRangeDateRule : ModelClientValidationRule
    {
        public ModelClientValidationRangeDateRule(string errorMessage,
            DateTime minValue, DateTime maxValue)
        {
            ErrorMessage = errorMessage;
            ValidationType = "rangedate";

            ValidationParameters["min"] = minValue.ToString("MM/dd/yyyy");
            ValidationParameters["max"] = maxValue.ToString("MM/dd/yyyy");
        }
    }
}