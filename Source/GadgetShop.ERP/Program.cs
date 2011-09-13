using CommonServiceLocator.NinjectAdapter;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using GadgetShop.Domain.Orders;
using GadgetShop.Domain;
using System;
using GadgetShop.Infrastructure.Messaging;
using GadgetShop.ERP.Modules;

namespace GadgetShop.ERP
{
    class Program
    {
        public static IKernel Kernel { get; private set; }

        static Program()
        {
            Kernel = new StandardKernel(
                new InfrastructureModule()
                );
            var locator = new NinjectServiceLocator(Kernel);
            ServiceLocator.SetLocatorProvider(() => locator);
            Kernel.Bind<IServiceLocator>().ToConstant(locator);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Starting up the juicy ERP system");

            var messageBus = Kernel.Get<IMessageBus>();
            messageBus.SubscribeTo<Order>(MessagePartitions.Orders, OrderReceived);

            Console.WriteLine("Ready to receive orders");

            Console.ReadLine();
        }

        static void OrderReceived(Order order)
        {
            Console.WriteLine("Order received");
        }

    }
}
