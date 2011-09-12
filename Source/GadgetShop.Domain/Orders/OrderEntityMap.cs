using GadgetShop.Infrastructure.Entities.TableStorage;

namespace GadgetShop.Domain.Orders
{
    public class OrderEntityMap : EntityMap<Order>
    {
        public OrderEntityMap()
        {
            PartitionKey.ToProperty(o => o.UserId);
            RowKey.ToProperty(o => o.Id);
        }
    }
}
