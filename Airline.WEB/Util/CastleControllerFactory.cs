using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace Airline.WEB.Util
{
    public class CastleControllerFactory : DefaultControllerFactory
    {
        public IWindsorContainer Container { get; protected set; }

        public CastleControllerFactory(IWindsorContainer container)
        {
            this.Container = container ?? throw new ArgumentNullException("Container is null");
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return Container?.Resolve(controllerType) as IController;
        }

        public override void ReleaseController(IController controller)
        {
            var disposableController = controller as IDisposable;
            disposableController?.Dispose();

            Container.Release(controller);
        }
    }
}