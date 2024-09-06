using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_console
{
    public class SupportChat
    {
        public string Id;
        public string StudentId;
        public string AdministratorId;

        public SupportChat(string studentId, string administratorId)
        {
        }

        public void SendMessage(string senderId, string message)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(string messageId)
        {
            throw new NotImplementedException();
        }

        public List<ChatMessage> GetMessages()
        {
            throw new NotImplementedException();
        }
    }
}
