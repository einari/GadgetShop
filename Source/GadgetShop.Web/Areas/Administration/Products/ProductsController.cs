using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetShop.Domain.Products;

namespace GadgetShop.Web.Areas.Administration.Products
{
    public class ProductsController : Controller
    {
        IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public ActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }

        [HttpPost]
        public ActionResult UploadImage()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(string name, string shortDescription, string description, string price)
        {
            double actualPrice;

            double.TryParse(price, out actualPrice);

            _productRepository.New(name, shortDescription, description, actualPrice);
            return RedirectToAction("Index");
        }

    }
}
