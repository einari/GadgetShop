using System;
using System.Linq;
using GadgetShop.Domain.Carts;
using GadgetShop.Infrastructure.Entities;
using GadgetShop.Domain.Products;

namespace GadgetShop.Domain.Orders
{
    public class OrderService : IOrderService
    {
        ICartRepository _cartRepository;
        IOrderRepository _orderRepository;
        IProductRepository _productRepository;

        public OrderService(ICartRepository cartRepository, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public void PlaceOrderFromCurrentCart()
        {
            var cart = _cartRepository.Get();

            var order = new Order 
            { 
                Sum = cart.Sum
            };

            foreach (var cartItem in cart.Items)
            {
                var orderLine = new OrderLine
                {
                };

                order.Lines.Add(orderLine);
            
            }

            order.Lines = cart.Items.Select(
                c => new OrderLine 
                { 

                }).ToList();

            _orderRepository.Insert(order);
        }
    }
}
