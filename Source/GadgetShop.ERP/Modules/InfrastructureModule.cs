﻿using GadgetShop.Infrastructure.Entities;
using Ninject.Modules;
using GadgetShop.Infrastructure.Security;
using GadgetShop.Infrastructure.Content;
using GadgetShop.Infrastructure.Images;
using GadgetShop.Infrastructure.Serialization;
using GadgetShop.Infrastructure.Messaging;
using Ninject.Activation;

namespace GadgetShop.ERP.Modules
{
    public class InfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISerializer>().To<Serializer>().InSingletonScope();

            Bind<MessageBusConfiguration>().ToMethod(CreateMessageBusConfiguration);
            Bind<IMessageBus>().To<MessageBus>().InSingletonScope();
        }


        MessageBusConfiguration CreateMessageBusConfiguration(IContext context)
        {
            var configuration = new MessageBusConfiguration
            {
                Identity = "owner",
                Key = "Gg5mXkR6eivBk5ZchkL3NHNOoPO0atG1mrSHQK1LWeM=",
                Namespace = "gadgetshop"
            };
            return configuration;
        }
    }
}