using FluentNHibernate.Mapping;

namespace GadgetShop.Domain.Orders
{
    public class OrderClassMap : ClassMap<Order>
    {
        public OrderClassMap()
        {
            Table("Orders");
            Id(o => o.Id).GeneratedBy.Assigned();
            Map(o => o.Id);
            Map(o => o.Placed);
            Map(o => o.Sum);
            Map(o => o.IsConfirmed);
        }
    }
}
