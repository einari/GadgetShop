using FluentNHibernate.Cfg;
using NHibernate;

namespace GadgetShop.Infrastructure.Entities
{
	public class EntityContextConnection
	{
		public ISessionFactory SessionFactory { get; private set; }
		public FluentConfiguration FluentConfiguration { get; private set; }
		public global::NHibernate.Cfg.Configuration Configuration { get; private set; }

		public EntityContextConnection()
		{
			FluentConfiguration = Fluently.Configure().
				Mappings(m => m.FluentMappings.AddFromAssemblyOf<EntityContextConnection>().Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never()));
		}

		public void Configure()
		{
			Configuration = FluentConfiguration.BuildConfiguration();
			SessionFactory = Configuration.BuildSessionFactory();
		}
	}
}
