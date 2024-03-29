﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using CommonServiceLocator.NinjectAdapter;
using FluentNHibernate.Cfg.Db;
using GadgetShop.Domain.Products;
using GadgetShop.Infrastructure.Entities;
using GadgetShop.Web.Binders;
using GadgetShop.Web.Modules;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Ninject.Web.Mvc;

namespace GadgetShop.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            ModelBinders.Binders.AddFor<Product>();

            var kernel = new StandardKernel(
                new ConfigurationModule(),
                new AzureConfigurationModule(),
                new InfrastructureModule(), 
                new DomainModule()
            );

            var locator = new NinjectServiceLocator(kernel);
            ServiceLocator.SetLocatorProvider(()=>locator);
            kernel.Bind<IServiceLocator>().ToConstant(locator);

            ConfigureEntityContext(kernel);

            return kernel;
        }

        void ConfigureEntityContext(IKernel kernel)
        {
            var configuration = kernel.Get<Configuration>();
            if (configuration.UseSqlForData)
            {
                var entityContextConnection = new EntityContextConnection();
                entityContextConnection.FluentConfiguration.
                    Database(MsSqlConfiguration.MsSql2008.ConnectionString(configuration.DataConnectionString)).
                    Mappings(m => m.FluentMappings.AddFromAssemblyOf<GadgetShop.Domain.Products.ProductClassMap>());
                entityContextConnection.Configure();
                kernel.Bind<EntityContextConnection>().ToConstant(entityContextConnection);
                kernel.Bind(typeof(IEntityContext<>)).To(typeof(EntityContext<>)).InRequestScope();
            }
            else
            {
                kernel.Bind(typeof(IEntityContext<>)).To(typeof(GadgetShop.Infrastructure.Entities.TableStorage.EntityContext<>)).InRequestScope();
            }
        }

        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            RelocateViews("Features",string.Empty);
        }


        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var featuresNamespace = typeof(MvcApplication).Assembly.GetName().Name + ".Features";

            var query = from t in Assembly.GetExecutingAssembly().GetTypes()
                        where t.Namespace != null && t.Namespace.StartsWith(featuresNamespace) &&
                              t.IsSubclassOf(typeof(Controller))
                        select t.Namespace;
            var namespaces = query.ToArray();


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                namespaces
            );
        }


        /// <summary>
        /// Changes the default convention for locations of Views and Master pages for all view engines
        /// </summary>
        /// <param name="siteRelativePath">Relative path within the site from root of site you want your views to be found</param>
        /// <remarks>
        /// By default ASP.net MVC has its views located in the Views folder of your site.
        /// This method can automatically change that location if one likes.
        /// </remarks>
        protected void RelocateViews(string siteRelativePath, string areaSiteRelativePath)
        {
            foreach (var viewEngine in ViewEngines.Engines)
            {
                if (viewEngine is VirtualPathProviderViewEngine)
                {
                    var virtualPathViewEngine = viewEngine as VirtualPathProviderViewEngine;

                    virtualPathViewEngine.MasterLocationFormats =
                        ReplaceInStrings(virtualPathViewEngine.MasterLocationFormats, "Views", siteRelativePath);
                    virtualPathViewEngine.ViewLocationFormats =
                        ReplaceInStrings(virtualPathViewEngine.ViewLocationFormats, "Views", siteRelativePath);
                    virtualPathViewEngine.PartialViewLocationFormats =
                        ReplaceInStrings(virtualPathViewEngine.PartialViewLocationFormats, "Views", siteRelativePath);

                    virtualPathViewEngine.AreaMasterLocationFormats =
                        ReplaceInStrings(virtualPathViewEngine.AreaMasterLocationFormats, "Views", areaSiteRelativePath);
                    virtualPathViewEngine.AreaViewLocationFormats =
                        ReplaceInStrings(virtualPathViewEngine.AreaViewLocationFormats, "Views", areaSiteRelativePath);
                    virtualPathViewEngine.AreaPartialViewLocationFormats =
                        ReplaceInStrings(virtualPathViewEngine.AreaPartialViewLocationFormats, "Views", areaSiteRelativePath);
                }
            }
        }

        private static string[] ReplaceInStrings(IEnumerable<string> strings, string partToReplace, string replaceWith)
        {
            return strings.Select(@string => @string.Replace(partToReplace, replaceWith)).ToArray();
        }
    }
}