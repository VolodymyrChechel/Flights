using System.Web.Mvc;
using Airline.BLL.Util;
using Airline.WEB.Util;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Airline.WEB
{
    public static class IocContainer
    {
        private static IWindsorContainer _container;

        public static void Setup()
        {
            _container = new WindsorContainer().Install(FromAssembly.This());
            var bllInstaller = new BllWindsorInstaller("AirlineContext");
            _container.Install(bllInstaller);       

            CastleControllerFactory controllerFactory = new CastleControllerFactory(_container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}