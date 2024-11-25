using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class ChatMessage
    {
        public string SenderId;
        public abstract DateTime Timestamp { get; set; }

        public ChatMessage(string senderId)
        {
            SenderId = senderId;
        }

        public abstract string Serialize();
        public abstract int GetSize();
    }
}
