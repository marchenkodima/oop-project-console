using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class TextChatMessage : ChatMessage
    {
        public string message;
        private DateTime timestamp;
        public override DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }

        public TextChatMessage(string senderId, string message) : base(senderId)
        {
            this.message = message;
            this.timestamp = DateTime.Now;
        }

        public override string Serialize()
        {
            return $"{Timestamp}: {SenderId} - {message}";
        }

        public override int GetSize()
        {
            return Encoding.UTF8.GetByteCount(Serialize());
        }
    }
}
