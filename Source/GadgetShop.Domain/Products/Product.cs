using System;
using GadgetShop.Infrastructure.Entities;

namespace GadgetShop.Domain.Products
{
    public class Product : IHaveId
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
