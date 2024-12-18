using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class ChatRepository
    {
        public ObservableCollection<Chat> Chats = new ObservableCollection<Chat>();

        public ChatRepository()
        {
            Chats.Add(new Chat("Chat 1"));
            Chats.Add(new Chat("Chat 2"));
            Chats.Add(new Chat("Chat 3"));
        }

        public ObservableCollection<Chat> GetAllChats()
        {
            return Chats;
        }

        public void AddChat(Chat chat)
        {
            Chats.Add(chat);
        }
    }
}
