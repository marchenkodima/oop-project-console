using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Chat
    {
        private List<ChatMessage> Messages;

        public Chat()
        {
            Messages = new List<ChatMessage>();
        }

        public void SendMessage(ChatMessage message)
        {
            Messages.Add(message);
        }

        public void DeleteMessage(ChatMessage message)
        {
            Messages.Remove(message);
        }

        public List<ChatMessage> GetMessages()
        {
            return Messages;
        }
    }
}
