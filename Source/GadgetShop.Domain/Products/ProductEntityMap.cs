using GadgetShop.Infrastructure.Entities.TableStorage;

namespace GadgetShop.Domain.Products
{
    public class ProductEntityMap : EntityMap<Product>
    {
        public ProductEntityMap()
        {
            PartitionKey.ToProperty(p => p.Id);
            RowKey.ToProperty(p => p.Id);
        }
    }
}
