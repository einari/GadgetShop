using System;
using System.Threading;
using GadgetShop.Infrastructure.Serialization;
using Microsoft.ServiceBus.Messaging;

namespace GadgetShop.Infrastructure.Messaging
{
    public class Receiver<T>
    {
        MessageReceiver _receiver;
        MessageReceived<T> _messageCallback;
        ISerializer _serializer;

        Receiver(ISerializer serializer, MessageReceiver receiver, MessageReceived<T> messageCallback)
        {
            _serializer = serializer;
            _receiver = receiver;
            _messageCallback = messageCallback;
            _receiver.BeginReceive(ReceiverCallback, null);
        }

        public static Receiver<T> Start(ISerializer serializer, MessageReceiver receiver, MessageReceived<T> messageCallback)
        {
            var r = new Receiver<T>(serializer, receiver, messageCallback);
            return r;
        }

        void ReceiverCallback(IAsyncResult asyncResult)
        {
            try
            {
                var message = _receiver.EndReceive(asyncResult);
                var actualMessage = message.GetBody<Message>();
                if (typeof(T).AssemblyQualifiedName.Equals(actualMessage.MessageType))
                {
                    var receivedMessage = (T)_serializer.FromJson(typeof(T), actualMessage.Content);
                    _messageCallback(receivedMessage);
                    message.Complete();
                }
            }
            catch { }
            finally
            {
                _receiver.BeginReceive(ReceiverCallback, null);
            }
        }
    }
}
