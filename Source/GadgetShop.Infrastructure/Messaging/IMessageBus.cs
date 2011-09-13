using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GadgetShop.Infrastructure.Messaging
{
    public interface IMessageBus
    {
        void Send<T>(string partition, T message);
        void SubscribeTo<T>(string partition, MessageReceived<T> messageCallback);
    }
}
