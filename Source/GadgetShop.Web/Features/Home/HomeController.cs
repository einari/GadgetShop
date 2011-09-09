using System.Web.Mvc;
using GadgetShop.Domain.Products;
using GadgetShop.Infrastructure.Entities;

namespace GadgetShop.Web.Features.Home
{
    public class HomeController : Controller
    {
        IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository, IEntityContext<Product> entityContext)
        {
            _productRepository = productRepository;
        }


        public ActionResult Index()
        {
            var products = _productRepository.GetTopProducts(4);
            return View(products);
        }
    }
}
