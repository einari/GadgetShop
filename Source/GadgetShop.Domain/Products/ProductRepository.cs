using System.Linq;
using System.Collections.Generic;
using GadgetShop.Infrastructure.Entities;
using System;

namespace GadgetShop.Domain.Products
{
    public class ProductRepository : IProductRepository
    {
        IEntityContext<Product> _productEntityContext;

        public ProductRepository(IEntityContext<Product> productEntityContext)
        {
            _productEntityContext = productEntityContext;
        }

        public IEnumerable<Product> GetTopProducts(int count)
        {
            return _productEntityContext.Entities.Take(count);
        }

        public Product GetById(Guid id)
        {
            return _productEntityContext.GetById(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productEntityContext.Entities;
        }

        public void New(string name, string shortDescription, string description, double price)
        {
            var product = new Product
            {
                Name = name,
                ShortDescription = shortDescription,
                Description = description,
                Price = price
            };
            _productEntityContext.Insert(product);
        }
    }
}
