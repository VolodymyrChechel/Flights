using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace Airline.WEB.Validators
{
    public class NotEqualAttribute : ValidationAttribute, IClientValidatable
    {
        public string ComparableProperty { get; private set; }

        public NotEqualAttribute(string comparableProperty)
        {
            ComparableProperty = comparableProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(ComparableProperty);
            if (property == null)
            {
                return new ValidationResult(
                    string.Format(CultureInfo.CurrentCulture, "{0} is unknown property",
                        ComparableProperty));
            }
            var comporableValue = property.GetValue(validationContext.ObjectInstance, null);
            if (object.Equals(value, comporableValue))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return null;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = ErrorMessage,
                ValidationType = "notequalto"
            };
            rule.ValidationParameters["other"] = ComparableProperty;
            yield return rule;
        }
    }
}