using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_console
{
    class ChatMessage
    {
        public string id;
        public string senderId;
        public string receiverId;
        public string message;
        public DateTime timestamp;

        public ChatMessage(string senderId, string receiverId, string message)
        {
            this.senderId = senderId;
            this.receiverId = receiverId;
            this.message = message;
            this.timestamp = DateTime.Now;
        }
    }
}
