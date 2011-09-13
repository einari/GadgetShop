using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Ninject;
using GadgetShop.Client.Modules;
using CommonServiceLocator.NinjectAdapter;
using Microsoft.Practices.ServiceLocation;

namespace GadgetShop.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IKernel Kernel { get; private set; }

        static App()
        {
            Kernel = new StandardKernel(
                new InfrastructureModule()
                );
            var locator = new NinjectServiceLocator(Kernel);
            ServiceLocator.SetLocatorProvider(() => locator);
            Kernel.Bind<IServiceLocator>().ToConstant(locator);
        }
    }
}
