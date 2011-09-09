using System;
using System.Web.Mvc;
using GadgetShop.Domain.Carts;
using GadgetShop.Domain.Products;

namespace GadgetShop.Web.Features.Carts
{
    public class CartsController : Controller
    {
        ICartRepository _cartRepository;
        IProductRepository _productRepository;

        public CartsController(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
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
            var cart = _cartRepository.Get();
            var cartViewModel = new CartViewModel(cart, _productRepository);
            return View(cartViewModel);
        }

    }
}
