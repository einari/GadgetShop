using Ninject.Modules;
using GadgetShop.Domain.Products;

namespace GadgetShop.Web.Modules
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductRepository>().To<ProductRepository>().InRequestScope();
        }
    }
}