using Ninject.Modules;
using MovieWebsite.Domain.Interfaces;
using MovieWebsite.Domain;

namespace MovieWebsite.Service
{
    public class ServiceNinjectModule : NinjectModule
    {
        private string connectionString;
        public ServiceNinjectModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<ApplicationUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}