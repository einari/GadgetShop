using System;
using Ninject.Modules;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace GadgetShop.Web.Modules
{
    public class ConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            var configuration = RoleEnvironment.IsAvailable?Configuration.FromRoleEnvironment():Configuration.FromApplicationConfig();
            Bind<Configuration>().ToConstant(configuration);
        }
    }
}