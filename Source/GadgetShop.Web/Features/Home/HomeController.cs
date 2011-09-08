using System.Web.Mvc;
using GadgetShop.Domain.Products;

namespace GadgetShop.Web.Features.Home
{
    public class HomeController : Controller
    {
        IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
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
