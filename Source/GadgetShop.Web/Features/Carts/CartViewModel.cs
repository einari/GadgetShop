using System.Collections.Generic;
using GadgetShop.Domain.Carts;
using GadgetShop.Domain.Products;

namespace GadgetShop.Web.Features.Carts
{
    public class CartViewModel
    {
        Cart _cart;
        List<CartItemViewModel> _items;

        public CartViewModel(Cart cart, IProductRepository productRepository)
        {
            _cart = cart;
            _items = new List<CartItemViewModel>();
            foreach( var item in cart.Items )
            {
                var product = productRepository.GetById(item.ProductId);
                var cartItemViewModel = new CartItemViewModel(item, product);
                _items.Add(cartItemViewModel);
            }
        }

        public IEnumerable<CartItemViewModel> Items { get { return _items;} }

        public int TotalItems { get { return _cart.TotalItems; } }
        public string Sum { get { return _cart.Sum.ToString(); } }
    }
}