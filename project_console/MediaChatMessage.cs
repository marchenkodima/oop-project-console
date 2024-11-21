using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_console
{
    public class MediaChatMessage : ChatMessage
    {
        public byte[] payload;
        private DateTime timestamp;

        public override DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }

        public MediaChatMessage(string senderId, byte[] payload) : base(senderId)
        {
            throw new NotImplementedException();
        }

        public override string Serialize()
        {
            throw new NotImplementedException();
        }
        public override int GetSize()
        {
            throw new NotImplementedException();
        }
    }
}
