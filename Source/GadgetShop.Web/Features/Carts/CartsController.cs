using System;
using System.Web.Mvc;
using GadgetShop.Domain.Carts;
using GadgetShop.Domain.Products;

namespace GadgetShop.Web.Features.Carts
{
    public class CartsController : Controller
    {
        ICartRepository _cartRepository;

        public CartsController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            _cartRepository.AddItem(product.Id, 1, product.Price);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    }
}
