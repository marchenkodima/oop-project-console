using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_console
{
    public abstract class ChatMessage
    {
        public string SenderId;
        public abstract DateTime Timestamp { get; set; }

        public ChatMessage(string senderId)
        {
            throw new NotImplementedException();
        }

        public abstract string Serialize();
        public abstract int GetSize();
    }
}
