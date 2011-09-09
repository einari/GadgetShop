﻿using Ninject.Modules;
using GadgetShop.Infrastructure.Entities;
using System.Configuration;
using FluentNHibernate.Cfg.Db;
using Microsoft.WindowsAzure;


namespace GadgetShop.Web.Modules
{
    public class EntitiesModule : NinjectModule
    {
        public override void Load()
        {
            var connectionString = "UseDevelopmentStorage=true";
            var account = CloudStorageAccount.Parse(connectionString);
            Bind<CloudStorageAccount>().ToConstant(account);
            Bind(typeof(IEntityContext<>)).To(typeof(GadgetShop.Infrastructure.Entities.TableStorage.EntityContext<>)).InRequestScope();
                

            

            /*
            var connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            var entityContextConnection = new EntityContextConnection();
            entityContextConnection.FluentConfiguration.
                Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString)).
                Mappings(m => m.FluentMappings.AddFromAssemblyOf<GadgetShop.Domain.Products.ProductClassMap>());
            entityContextConnection.Configure();
            Bind<EntityContextConnection>().ToConstant(entityContextConnection);

            Bind(typeof(IEntityContext<>)).To(typeof(EntityContext<>)).InRequestScope();*/
        }

    }
}