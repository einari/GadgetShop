using System.Web.Mvc;
using GadgetShop.Domain.Orders;

namespace GadgetShop.Web.Features.Orders
{
    public class OrdersController : Controller
    {
        IOrderService _orderService;
        IOrderRepository _orderRepository;

        public OrdersController(IOrderService orderService, IOrderRepository orderRepository)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
        }


        [HttpPost]
        public ActionResult Place()
        {
            _orderService.PlaceOrderFromCurrentCart();
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var orders = _orderRepository.GetAll();
            return View(orders);
        }
    }
}
