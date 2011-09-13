using System.Collections.Generic;
using System.Linq;
using GadgetShop.Infrastructure.Serialization;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Description;
using Microsoft.ServiceBus.Messaging;

namespace GadgetShop.Infrastructure.Messaging
{
    public class MessageBus : IMessageBus
    {
        Dictionary<string, Queue> _queues = new Dictionary<string, Queue>();
        Dictionary<string, MessageSender> _senders = new Dictionary<string, MessageSender>();

        ServiceBusNamespaceClient _client;
        SharedSecretCredential _credential;
        MessagingFactory _messagingFactory;
        MessageBusConfiguration _configuration;
        ISerializer _serializer;

        public MessageBus(MessageBusConfiguration configuration, ISerializer serializer)
        {
            _configuration = configuration;
            _serializer = serializer;

            // Todo : If you want to run against the production/live one in AppFabric, uncomment this 
            //Environment.SetEnvironmentVariable("RELAYENV", "live");

            var uri = ServiceBusEnvironment.CreateServiceUri("sb", configuration.Namespace, string.Empty);
            _credential = TransportClientCredentialBase.CreateSharedSecretCredential(configuration.Identity, configuration.Key);
            _client = new ServiceBusNamespaceClient(uri, _credential);
            _messagingFactory = MessagingFactory.Create(uri, _credential);
        }


        Queue GetOrCreateQueueFromPartitionName(string partition)
        {
            partition = partition.ToLowerInvariant();
            if (_queues.ContainsKey(partition))
                return _queues[partition];

            Queue queue = null;
            if (!DoesQueueExist(partition))
                queue = _client.CreateQueue(partition);
            else
                queue = _client.GetQueue(partition);

            _queues[partition] = queue;


            return queue;
        }

        bool DoesQueueExist(string queueName)
        {
            return _client.GetQueues().Where(q => q.Path.Equals(queueName.ToLowerInvariant())).Count() > 0;
        }

        public void Send<T>(string partition, T message)
        {
            partition = partition.ToLowerInvariant();
            var queue = GetOrCreateQueueFromPartitionName(partition);

            
            MessageSender sender;
            if (_senders.ContainsKey(partition))
                sender = _senders[partition];
            else
            {
                var queueClient = _messagingFactory.CreateQueueClient(queue);
                sender = queueClient.CreateSender();
                _senders[partition] = sender;
            }

            var actualMessage = new Message
            {
                MessageType = typeof(T).AssemblyQualifiedName,
                Content = _serializer.ToJson(message)
            };
            var messageToSend = BrokeredMessage.CreateMessage(actualMessage);
            sender.Send(messageToSend);
        }

        public void SubscribeTo<T>(string partition, MessageReceived<T> messageCallback)
        {
            var queue = GetOrCreateQueueFromPartitionName(partition);
            var queueClient = _messagingFactory.CreateQueueClient(queue);
            var receiver = queueClient.CreateReceiver();
            Receiver<T>.Start(_serializer, receiver, messageCallback);
        }
    }
}
