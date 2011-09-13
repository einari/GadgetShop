using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetShop.Domain.Products;
using System.IO;

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
        public ActionResult UploadImage(Guid productId)
        {
            if (Request.Files.Count == 1)
            {
                var file = Request.Files[0];
                var data = new byte[file.InputStream.Length];
                file.InputStream.Read(data, 0, data.Length);
                _productRepository.SetImage(productId, data);
            }

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
