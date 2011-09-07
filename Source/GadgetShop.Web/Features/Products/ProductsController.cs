using System.Web.Mvc;
using GadgetShop.Domain.Products;

namespace GadgetShop.Web.Features.Products
{
    public class ProductsController : Controller
    {
        public ActionResult Details(Product product)
        {
            return View(product);
        }
    }
}
