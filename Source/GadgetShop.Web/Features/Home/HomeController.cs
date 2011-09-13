using System.Web.Mvc;
using GadgetShop.Domain.Products;
using GadgetShop.Infrastructure.Entities;
using GadgetShop.Infrastructure.Messaging;
using GadgetShop.Domain.CustomerCare;
using GadgetShop.Domain;

namespace GadgetShop.Web.Features.Home
{
    public class HomeController : Controller
    {
        IProductRepository _productRepository;
        IMessageBus _messageBus;

        public HomeController(IProductRepository productRepository, IEntityContext<Product> entityContext, IMessageBus messageBus)
        {
            _productRepository = productRepository;
            _messageBus = messageBus;
        }


        public ActionResult Index()
        {
            var products = _productRepository.GetTopProducts(4);
            return View(products);
        }

        public ActionResult DoStuff()
        {
            _messageBus.Send(MessagePartitions.CustomerCare, new ChatMessage { Body = "Hello world" });
            return RedirectToAction("Index");
        }
    }
}
