using GadgetShop.Infrastructure.Entities;
using Ninject.Modules;
using GadgetShop.Infrastructure.Security;

namespace GadgetShop.Web.Modules
{
    public class InfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>().InRequestScope();
        }
    }
}