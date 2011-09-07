using System.Collections.Generic;

namespace GadgetShop.Domain.Products
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetTopProducts(int count);
    }
}
