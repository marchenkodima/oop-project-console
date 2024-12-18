using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Model;
using WpfApp1.Services;

namespace WpfApp1.ViewModel
{
    public class ChatManagerViewModel : INotifyPropertyChanged
    {
        public string ChatName { get; set; }

        private readonly ChatService _chatService;
        private readonly UserService _userService;

        public Chat SelectedChat {
            get
            {
                return _chatService.CurrentChat;
            }
            set
            {
                _chatService.CurrentChat = value;
            }
        }
        public User SelectedUser
        {
            get
            {
                return _userService.CurrentUser;
            }
            set
            {
                _userService.CurrentUser = value;
            }
        }
        public ObservableCollection<Chat> Chats { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ICollectionView ChatUsers { get; set; }

        private ChatRepository ChatRepository;
        private UserRepository UserRepository;

        public ICommand AddChatCommand { get; set; }
        public ICommand AddUserToChatCommand { get; set; }

        public ChatManagerViewModel(ChatRepository chatRepository, UserRepository userRepository)
        {
            _userService = new UserService();
            _chatService = new ChatService();

            _chatService.PropertyChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ChatUsers));
            };
            _userService.PropertyChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ChatUsers));
            };

            Chats = chatRepository.GetAllChats();
            Users = userRepository.GetAllUsers();
            ChatRepository = chatRepository;
            UserRepository = userRepository;
            AddChatCommand = new RelayCommand(AddChat, CanAddChat);
            AddUserToChatCommand = new RelayCommand(AddUserToChat, CanAddUserToChat);

            ChatUsers = new ListCollectionView(userRepository.GetAllUsers());
            ChatUsers.Filter = (obj) => obj is User user && user.Chats.Contains(_chatService.CurrentChat);
        }

        private bool CanAddChat(object obj)
        {
            return true;
        }

        private void AddChat(object obj)
        {
            if (CanAddChat(obj))
            {
                ChatRepository.AddChat(new Chat(ChatName));
            }
        }

        private bool CanAddUserToChat(object obj)
        {
            return true;
        }

        private void AddUserToChat(object obj)
        {
            if (CanAddChat(obj))
            {
                SelectedUser.AddChat(SelectedChat);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (propertyName == nameof(ChatUsers))
            {
                ChatUsers.Refresh();
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
