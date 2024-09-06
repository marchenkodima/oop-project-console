using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_console
{
    class Chat
    {
        public string id;
        public string studentId;
        public string administratorId;
        private ChatMessage[] messages;

        public Chat()
        {
        }

        public void SendMessage(string senderId, string receiverId, string message)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(int index)
        {
            throw new NotImplementedException();
        }

        public ChatMessage[] GetMessages()
        {
            throw new NotImplementedException();
        }
    }
}
