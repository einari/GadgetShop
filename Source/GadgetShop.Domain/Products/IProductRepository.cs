using System.Collections.Generic;
using System;

namespace GadgetShop.Domain.Products
{
    public interface IProductRepository
    {
        Product GetById(Guid id); 
        IEnumerable<Product> GetTopProducts(int count);
    }
}
