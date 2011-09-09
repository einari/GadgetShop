using System;
using GadgetShop.Infrastructure.Entities;

namespace GadgetShop.Domain.Carts
{
    public class CartItem : IHaveId
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public double Sum { get { return UnitPrice * Quantity; } }
    }
}
