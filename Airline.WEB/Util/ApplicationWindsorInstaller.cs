using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
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

            var controllers = Assembly.GetExecutingAssembly().GetTypes().
                Where(x => x.BaseType == typeof(Controller)).ToList();
            foreach (var controller in controllers)
            {
                container.Register(Component.For(controller).LifestylePerWebRequest());
            }
        }
    }
}