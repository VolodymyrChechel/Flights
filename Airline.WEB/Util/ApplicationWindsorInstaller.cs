using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Airline.BLL.DTO;
using Airline.BLL.Interfaces;
using Airline.BLL.Services;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Airline.WEB.Util
{
    public class ApplicationWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IWorkerService>().ImplementedBy<WorkerService>());
            container.Register(Component.For<IFlightService>().ImplementedBy<FlightService>());
            container.Register(Component.For<IAirportService>().ImplementedBy<AirportService>());
            container.Register(Component.For<IUserService>().ImplementedBy<UserService>());
            container.Register(Component.For<ICrewService>().ImplementedBy<CrewService>());
            container.Register(Component.For<IFlightParkService>().ImplementedBy<FlightParkService>());
            container.Register(Component.For<ITimetableService>().ImplementedBy<TimetableService>());

            var controllers = Assembly.GetExecutingAssembly().GetTypes().
                Where(x => x.BaseType == typeof(Controller)).ToList();
            foreach (var controller in controllers)
            {
                container.Register(Component.For(controller).LifestylePerWebRequest());
            }
        }
    }
}