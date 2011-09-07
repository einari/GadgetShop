using System.Linq;
using System.Collections.Generic;

namespace GadgetShop.Domain.Carts
{
    public class Cart
    {
        public Cart()
        {
            Items = new List<CartItem>();
        }

        public List<CartItem> Items { get; set; }

        public decimal Sum
        {
            get { return Items.Sum(i => i.Price); }
        }

        public int TotalItems
        {
            get { return Items.Sum(i => i.Quantity); }
        }
    }
}
