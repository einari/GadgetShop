using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GadgetShop.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            RelocateViews("Features");
        }


        /// <summary>
        /// Changes the default convention for locations of Views and Master pages for all view engines
        /// </summary>
        /// <param name="siteRelativePath">Relative path within the site from root of site you want your views to be found</param>
        /// <remarks>
        /// By default ASP.net MVC has its views located in the Views folder of your site.
        /// This method can automatically change that location if one likes.
        /// </remarks>
        protected void RelocateViews(string siteRelativePath)
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
                        ReplaceInStrings(virtualPathViewEngine.AreaMasterLocationFormats, "Views", siteRelativePath);
                    virtualPathViewEngine.AreaViewLocationFormats =
                        ReplaceInStrings(virtualPathViewEngine.AreaViewLocationFormats, "Views", siteRelativePath);
                    virtualPathViewEngine.AreaPartialViewLocationFormats =
                        ReplaceInStrings(virtualPathViewEngine.AreaPartialViewLocationFormats, "Views", siteRelativePath);
                }
            }
        }

        private static string[] ReplaceInStrings(IEnumerable<string> strings, string partToReplace, string replaceWith)
        {
            return strings.Select(@string => @string.Replace(partToReplace, replaceWith)).ToArray();
        }


    }
}