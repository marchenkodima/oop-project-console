using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
    public class ChatService : INotifyPropertyChanged
    {
        private Chat _currentChat;
        public Chat CurrentChat
        {
            get => _currentChat;
            set
            {
                if (_currentChat != value)
                {
                    if (_currentChat != null)
                    {
                        _currentChat.PropertyChanged -= CurrentUser_PropertyChanged;
                    }

                    _currentChat = value;

                    if (_currentChat != null)
                    {
                        _currentChat.PropertyChanged += CurrentUser_PropertyChanged;
                    }

                    OnPropertyChanged(nameof(CurrentChat));
                }
            }
        }

        private void CurrentUser_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Chat.Messages))
            {
                OnPropertyChanged(nameof(CurrentChat));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
