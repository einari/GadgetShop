using Microsoft.WindowsAzure;
using Ninject;
using Ninject.Modules;
using Ninject.Activation;

namespace GadgetShop.Web.Modules
{
    public class AzureConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<CloudStorageAccount>().ToMethod(GetCloudStorageAccount);
        }

        CloudStorageAccount GetCloudStorageAccount(IContext context)
        {
            var configuration = context.Kernel.Get<Configuration>();
            var connectionString = configuration.StorageAccountConnectionString;
            var account = CloudStorageAccount.Parse(connectionString);
            return account;
        }
    }
}