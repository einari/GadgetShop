using Ninject.Modules;
using GadgetShop.Domain.Products;
using GadgetShop.Domain.Carts;

namespace GadgetShop.Web.Modules
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductRepository>().To<ProductRepository>().InRequestScope();
            Bind<ICartRepository>().To<CartRepository>().InRequestScope();
        }
    }
}