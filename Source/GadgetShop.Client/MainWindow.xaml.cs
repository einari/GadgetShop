using System;
using System.Windows;
using GadgetShop.Domain;
using GadgetShop.Domain.CustomerCare;
using GadgetShop.Infrastructure.Messaging;
using Ninject;

namespace GadgetShop.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var messageBus = App.Kernel.Get<IMessageBus>();
            messageBus.SubscribeTo<ChatMessage>(MessagePartitions.CustomerCare, ChatMessageReceived);
        }

        void ChatMessageReceived(ChatMessage message)
        {
            Action a = () => _messages.Items.Add(message.Body);
            Dispatcher.BeginInvoke(a);
        }
    }
}
