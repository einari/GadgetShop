
using FluentNHibernate.Mapping;
namespace GadgetShop.Domain.Products
{
    public class ProductClassMap : ClassMap<Product>
    {
        public ProductClassMap()
        {
            Table("Products");
            Id(p => p.Id).GeneratedBy.Assigned();
            Map(p => p.Name);
            Map(p => p.ShortDescription);
            Map(p => p.Description);
            Map(p => p.Price);
        }
    }
}
