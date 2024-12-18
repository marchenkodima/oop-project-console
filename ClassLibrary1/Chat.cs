using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Chat : INotifyPropertyChanged
    {
        public string Name { get; set; }

        private ObservableCollection<ChatMessage> _messages;
        public ObservableCollection<ChatMessage> Messages
        {
            get => _messages;
            set
            {
                if (_messages != value)
                {
                    _messages = value;
                    OnPropertyChanged(nameof(_messages));
                }
            }
        }

        public Chat(string name)
        {
            Messages = new ObservableCollection<ChatMessage>();
            Name = name;
        }

        public void SendMessage(ChatMessage message)
        {
            Messages.Add(message);
        }

        public void DeleteMessage(ChatMessage message)
        {
            Messages.Remove(message);
        }

        public ObservableCollection<ChatMessage> GetMessages()
        {
            return Messages;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
