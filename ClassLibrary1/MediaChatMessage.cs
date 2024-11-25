using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
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
            this.payload = payload;
            this.timestamp = DateTime.Now;
        }

        public override string Serialize()
        {
            // Convert the payload byte array to a string representation
            string payloadString = Convert.ToBase64String(payload);

            // Serialize the senderId, payload, and timestamp
            string serializedMessage = $"{SenderId}:{payloadString}:{Timestamp}";

            return serializedMessage;
        }

        public override int GetSize()
        {
            // Calculate the size of the serialized message
            int size = sizeof(char) * (SenderId.Length + 1) + sizeof(char) * (payload.Length * 2) + sizeof(char) * 2 + sizeof(long);

            return size;
        }
    }
}
