using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetShop.Domain.Products;

namespace GadgetShop.Web.Features.Carts
{
    public class CartsController : Controller
    {
        [HttpPost]
        public ActionResult Add(Product product)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    }
}
