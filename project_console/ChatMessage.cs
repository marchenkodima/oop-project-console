using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_console
{
    public class ChatMessage
    {
        public string Id;
        public string ChatId;
        public string SenderId;
        public string Message;
        public DateTime Timestamp;

        public ChatMessage(string senderId, string message, string chatId)
        {
            this.SenderId = senderId;
            this.Message = message;
            this.Timestamp = DateTime.Now;
            this.ChatId = chatId;
        }
    }
}
