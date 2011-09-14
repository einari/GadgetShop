using Microsoft.WindowsAzure.ServiceRuntime;
using System.Configuration;

namespace GadgetShop.Web
{
    public class Configuration
    {
        public bool UseSqlForData { get; private set; }
        public string DataConnectionString { get; private set; }
        public string StorageAccountConnectionString { get; private set; }

        public string QueueNamespace { get; private set; }
        public string QueueIdentity { get; private set; }
        public string QueueKey { get; private set; }


        public static Configuration FromApplicationConfig()
        {
            var configuration = new Configuration();

            configuration.UseSqlForData = bool.Parse(ConfigurationManager.AppSettings["UseSqlForData"]);
            configuration.DataConnectionString = ConfigurationManager.ConnectionStrings["DataConnectionString"].ConnectionString;
            configuration.StorageAccountConnectionString = ConfigurationManager.AppSettings["StorageAccountConnectionString"];
            configuration.QueueNamespace = ConfigurationManager.AppSettings["QueueNamespace"];
            configuration.QueueIdentity = ConfigurationManager.AppSettings["QueueIdentity"];
            configuration.QueueKey = ConfigurationManager.AppSettings["QueueKey"];

            return configuration;
        }


        public static Configuration FromRoleEnvironment()
        {
            var configuration = new Configuration();

            configuration.UseSqlForData = bool.Parse(RoleEnvironment.GetConfigurationSettingValue("UseSqlForData"));
            configuration.DataConnectionString = RoleEnvironment.GetConfigurationSettingValue("DataConnectionString");
            configuration.StorageAccountConnectionString = RoleEnvironment.GetConfigurationSettingValue("StorageAccountConnectionString");
            configuration.QueueNamespace = RoleEnvironment.GetConfigurationSettingValue("QueueNamespace");
            configuration.QueueIdentity = RoleEnvironment.GetConfigurationSettingValue("QueueIdentity");
            configuration.QueueKey = RoleEnvironment.GetConfigurationSettingValue("QueueKey");

            return configuration;
        }

    }
}