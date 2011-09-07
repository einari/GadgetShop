using GadgetShop.Infrastructure.Entities;
using Ninject.Modules;

namespace GadgetShop.Web.Modules
{
    public class InfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IEntityContext<>)).To(typeof(EntityContext<>)).InRequestScope();
        }
    }
}