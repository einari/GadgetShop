using System;
using GadgetShop.Infrastructure.Entities;
using System.Collections.Generic;

namespace GadgetShop.Domain.Orders
{
    public class Order : IHaveId
    {
        public Order()
        {
            Lines = new List<OrderLine>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<OrderLine> Lines { get; set; }
        public double Sum { get; set; }
        public DateTime Placed { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
