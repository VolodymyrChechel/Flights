using Airline.DAL.Interfaces;
using Airline.DAL.Repositories;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Airline.BLL.Util
{
    public class BllWindsorInstaller : IWindsorInstaller
    {
        private string _connectionString;

        public BllWindsorInstaller(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUnitOfWork>().ImplementedBy<EFUnitOfWork>().DynamicParameters((r, k) =>
                {
                    k["connectionString"] = _connectionString;
                }));
        }
    }
}