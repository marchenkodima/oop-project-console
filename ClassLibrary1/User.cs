using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    interface IUser
    {
        string Name { get; set; }
        string Username { get; set; }
        string Id { get; set; }
        List<Chat> Chats { get; set; }

        bool SignIn(string username, string password);
        void AddChat(Chat chat);
    }

    public class User : IUser, ICloneable
    {
        public string Name { get; set; }
        public string Username { get; set; }
        private string Password { get; set; }
        public string Id { get; set; }
        public List<Chat> Chats { get; set; }

        public User(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = password;
            Chats = new List<Chat>();
            Id = Guid.NewGuid().ToString();
        }

        public bool SignIn(string username, string password)
        {
            if (Username == username && Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddChat(Chat chat)
        {
            Chats.Add(chat);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
