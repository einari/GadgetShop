using System;
using GadgetShop.Infrastructure.Entities;

namespace GadgetShop.Domain.Orders
{
    public class OrderLine : IHaveId
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Sum { get; set; }
    }
}
