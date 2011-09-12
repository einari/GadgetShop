﻿using System.Collections.Generic;
using System;

namespace GadgetShop.Domain.Products
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(Guid id); 
        IEnumerable<Product> GetTopProducts(int count);
        void New(string name, string shortDescription, string description, double price);
    }
}
