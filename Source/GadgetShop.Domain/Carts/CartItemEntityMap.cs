using GadgetShop.Infrastructure.Entities.TableStorage;

namespace GadgetShop.Domain.Carts
{
    public class CartItemEntityMap : EntityMap<CartItem>
    {
        public CartItemEntityMap()
        {
            PartitionKey.ToProperty(c => c.UserId);
            RowKey.ToProperty(c => c.Id);
        }
    }
}
