using System;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Globalization;
using System.Web;

namespace Airline.WEB.Binders
{
    //public class TimeSpanBinder : DefaultModelBinder
    //{
    //    protected override void BindProperty(
    //        ControllerContext controllerContext,
    //        ModelBindingContext bindingContext,
    //        PropertyDescriptor propertyDescriptor)
    //    {

    //        var propertyBinderAttribute = (propertyDescriptor);
    //        if (propertyBinderAttribute != null)
    //        {
    //            var binder = CreateBinder(propertyBinderAttribute);
    //            var value = binder.BindModel(controllerContext, bindingContext, propertyDescriptor);
    //            propertyDescriptor.SetValue(bindingContext.Model, value);
    //        }
    //        else
    //        {
    //            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
    //        }
    //    }
    //}

    public class TimeSpanValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return string.Compare("PlannedDepartureTime", prefix, true) == 0;
        }

        public ValueProviderResult GetValue(string key)
        {
            if (!ContainsPrefix(key))
            {
                return null;
            }

            var rawTime = HttpContext.Current.Request.Form["PlannedDepartureTime"];
            var time = DateTime.ParseExact(rawTime, "h:mm tt", CultureInfo.InvariantCulture);
            return new ValueProviderResult(time.TimeOfDay, null,
                CultureInfo.InvariantCulture);
        }
    }
}