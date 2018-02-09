using System.Web.Mvc;
using Airline.WEB.Binders;

namespace Airline.WEB
{
    public class TimeSpanValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new TimeSpanValueProvider();
        }
    }
}