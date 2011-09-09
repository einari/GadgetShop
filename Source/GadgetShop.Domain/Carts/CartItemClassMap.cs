using FluentNHibernate.Mapping;

namespace GadgetShop.Domain.Carts
{
    public class CartItemClassMap : ClassMap<CartItem>
    {
        public CartItemClassMap()
        {
            Table("CartItems");
            Id(c => c.Id).GeneratedBy.Assigned();
            Map(c => c.UserId);
            Map(c => c.ProductId);
            Map(c => c.Quantity);
            Map(c => c.UnitPrice);
        }
    }
}
