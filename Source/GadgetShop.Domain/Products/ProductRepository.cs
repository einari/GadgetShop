using System.Linq;
using System.Collections.Generic;
using GadgetShop.Infrastructure.Entities;

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
    }
}
