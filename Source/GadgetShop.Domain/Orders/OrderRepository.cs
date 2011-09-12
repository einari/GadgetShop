using GadgetShop.Infrastructure.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using GadgetShop.Infrastructure.Security;

namespace GadgetShop.Domain.Orders
{
    public class OrderRepository : IOrderRepository
    {
        IEntityContext<Order> _orderEntityContext;
        IEntityContext<OrderLine> _orderLineEntityContext;
        IUserService _userService;

        public OrderRepository(IEntityContext<Order> orderEntityContext, IEntityContext<OrderLine> orderLineEntityContext, IUserService userService)
        {
            _orderEntityContext = orderEntityContext;
            _orderLineEntityContext = orderLineEntityContext;
            _userService = userService;
        }

        public Order Get(Guid id)
        {
            var order = _orderEntityContext.GetById(id);
            PopulateLines(order);
            return order;
        }

        public void Insert(Order order)
        {
            order.UserId = _userService.GetCurrentUserId();
            order.Placed = DateTime.Now;
            _orderEntityContext.Insert(order);

            foreach (var orderLine in order.Lines)
                _orderLineEntityContext.Insert(orderLine);
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _orderEntityContext.Entities.Where(o => o.UserId == _userService.GetCurrentUserId());
            foreach (var order in orders)
                PopulateLines(order);
            
            return orders;
        }

        void PopulateLines(Order order)
        {
            order.Lines = _orderLineEntityContext.Entities.Where(o => o.OrderId == order.Id).ToList();
        }
    }
}
