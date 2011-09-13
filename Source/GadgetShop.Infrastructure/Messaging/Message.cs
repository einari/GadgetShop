using System;

namespace GadgetShop.Infrastructure.Messaging
{
    [Serializable]
    public class Message
    {
        public string MessageType { get; set; }
        public string Content { get; set; }
    }
}
