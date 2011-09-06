using System.Web.Mvc;
using GadgetShop.Domain.Products;

namespace GadgetShop.Web.Features.Home
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var products = new[] {
                new Product { Name = "Something" },
                new Product { Name = "Exciting" },
                new Product { Name = "Going" },
                new Product { Name = "On" }
            };

            return View(products);
        }

    }
}
