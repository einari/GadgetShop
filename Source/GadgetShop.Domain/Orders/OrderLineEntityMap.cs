using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GadgetShop.Infrastructure.Entities.TableStorage;

namespace GadgetShop.Domain.Orders
{
    public class OrderLineEntityMap : EntityMap<OrderLine>
    {
        public OrderLineEntityMap()
        {
            PartitionKey.ToProperty(o => o.OrderId);
            RowKey.ToProperty(o => o.Id);
        }
    }
}
