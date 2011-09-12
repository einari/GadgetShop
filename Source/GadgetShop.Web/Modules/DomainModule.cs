using Ninject.Modules;
using GadgetShop.Domain.Products;
using GadgetShop.Domain.Carts;
using GadgetShop.Domain.Orders;

namespace GadgetShop.Web.Modules
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductRepository>().To<ProductRepository>().InRequestScope();
            Bind<ICartRepository>().To<CartRepository>().InRequestScope();
            Bind<IOrderService>().To<OrderService>().InRequestScope();
            Bind<IOrderRepository>().To<OrderRepository>().InRequestScope();
        }
    }
}