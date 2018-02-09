
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Airline.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ValueProviderFactories.Factories.Insert(0, new TimeSpanValueProviderFactory());
            AutoMapperConfig.Initialize();

            IocContainer.Setup();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
