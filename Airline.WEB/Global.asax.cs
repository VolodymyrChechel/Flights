
using System;
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

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Airline.Common.NLog.NLog.LogError(sender.GetType(), exception.Message + "\n" + exception.StackTrace);
            Server.ClearError();
            Response.Redirect("~/Home/Error");
        }
    }
}
