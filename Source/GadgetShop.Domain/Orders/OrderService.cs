using System;
using System.Linq;
using GadgetShop.Domain.Carts;
using GadgetShop.Infrastructure.Entities;
using GadgetShop.Domain.Products;
using GadgetShop.Infrastructure.Messaging;

namespace GadgetShop.Domain.Orders
{
    public class OrderService : IOrderService
    {
        ICartRepository _cartRepository;
        IOrderRepository _orderRepository;
        IProductRepository _productRepository;
        IMessageBus _messageBus;

        public OrderService(ICartRepository cartRepository, IOrderRepository orderRepository, IProductRepository productRepository, IMessageBus messageBus)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _messageBus = messageBus;
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

            _messageBus.Send(MessagePartitions.Orders, order);

            _cartRepository.Clear();
        }
    }
}
