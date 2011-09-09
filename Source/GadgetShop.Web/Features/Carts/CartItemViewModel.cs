using GadgetShop.Domain.Carts;
using GadgetShop.Domain.Products;

namespace GadgetShop.Web.Features.Carts
{
    public class CartItemViewModel
    {
        CartItem _cartItem;

        public CartItemViewModel(CartItem cartItem, Product product)
        {
            _cartItem = cartItem;
            Product = product;
        }

        public Product Product { get; private set; }
        public string UnitPrice { get { return _cartItem.UnitPrice.ToString(); } }
        public int Quantity { get { return _cartItem.Quantity; } }
        public string Sum { get { return _cartItem.Sum.ToString(); } }
    }
}