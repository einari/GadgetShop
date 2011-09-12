using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GadgetShop.Domain.Orders
{
    public interface IOrderRepository
    {
        Order Get(Guid id);
        void Insert(Order order);
        IEnumerable<Order> GetAll();
    }
}
