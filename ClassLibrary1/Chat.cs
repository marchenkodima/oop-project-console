using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public delegate void MessageSentHandler(ChatMessage message);

    public class Chat : INotifyPropertyChanged
    {
        public string Name { get; set; }

        public event MessageSentHandler MessageSent;

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
            MessageSent?.Invoke(message);
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
