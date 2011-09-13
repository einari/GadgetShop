using GadgetShop.Infrastructure.Entities;
using Ninject.Modules;
using GadgetShop.Infrastructure.Security;
using GadgetShop.Infrastructure.Content;
using GadgetShop.Infrastructure.Images;
using GadgetShop.Infrastructure.Serialization;
using GadgetShop.Infrastructure.Messaging;
using Ninject.Activation;

namespace GadgetShop.Web.Modules
{
    public class InfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>().InRequestScope();
            Bind<IContentManager>().To<GadgetShop.Infrastructure.Content.BlobStorage.ContentManager>().InSingletonScope();
            Bind<IImageProcessor>().To<ImageProcessor>().InSingletonScope();
            Bind<IImageService>().To<ImageService>().InSingletonScope();
            Bind<ISerializer>().To<Serializer>().InSingletonScope();

            Bind<MessageBusConfiguration>().ToMethod(CreateMessageBusConfiguration);
            Bind<IMessageBus>().To<MessageBus>().InSingletonScope();
        }


        MessageBusConfiguration CreateMessageBusConfiguration(IContext context)
        {
            var configuration = new MessageBusConfiguration
            {
                Identity = "owner",
                Key = "",
                Namespace = ""
            };
            return configuration;
        }
    }
}