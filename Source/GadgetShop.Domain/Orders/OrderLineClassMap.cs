using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace GadgetShop.Domain.Orders
{
    public class OrderLineClassMap : ClassMap<OrderLine>
    {
        public OrderLineClassMap()
        {
            Table("OrderLines");
            Id(o => o.Id);
            Map(o => o.OrderId);
            Map(o => o.ProductName);
            Map(o => o.ProductDescription);
            Map(o => o.UnitPrice);
            Map(o => o.Quantity);
            Map(o => o.Sum);
        }
    }
}
