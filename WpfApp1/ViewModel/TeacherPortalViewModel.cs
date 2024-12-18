using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Model;
using WpfApp1.Services;

namespace WpfApp1.ViewModel
{
    public class TeacherPortalViewModel : INotifyPropertyChanged
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public string TaskInput { get; set; }
        public string AnswerInput { get; set; }
        public string FacultyInput { get; set; }

        private readonly UserService _userService;
        private readonly ChatService _chatService;

        public ObservableCollection<Course> TeacherCourses => _userService.CurrentUser?.Courses;
        public ObservableCollection<Chat> TeacherChats => _userService.CurrentUser?.Chats;
        public ObservableCollection<ChatMessage> ChatMessages => _chatService.CurrentChat?.Messages;

        public Course SelectedCourse { get; set; }
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

        public ICommand SignInCommand { get; set; }
        public ICommand SendMessageCommand { get; set; }
        public ICommand CreateTaskCommand { get; set; }
        public ICommand GetChatHistoryCommand { get; set; }

        private readonly UserRepository UserRepository;
        private readonly ChatRepository ChatRepository;

        public TeacherPortalViewModel(UserRepository userRepository, ChatRepository chatRepository)
        {
            Username = "";
            Password = "";
            SignInCommand = new RelayCommand(SignIn, CanSignIn);
            SendMessageCommand = new RelayCommand(SendMessage, CanSendMessage);
            CreateTaskCommand = new RelayCommand(CreateTask, CanCreateTask);
            GetChatHistoryCommand = new RelayCommand(GetChatHistory, CanGetChatHistory);
            UserRepository = userRepository;
            ChatRepository = chatRepository;

            _userService = new UserService();
            _userService.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(UserService.CurrentUser))
                {
                    OnPropertyChanged(nameof(TeacherCourses));
                    OnPropertyChanged(nameof(TeacherChats));
                }
            };

            _chatService = new ChatService();
            _chatService.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(ChatService.CurrentChat))
                {
                    OnPropertyChanged(nameof(ChatMessages));
                }
            };
        }

        private bool CanSignIn(object obj)
        {
            return true;
        }

        private void SignIn(object obj)
        {
            if (CanSignIn(obj))
            {
                var Teacher = UserRepository.GetTeacherByUsername(Username);
                if (Teacher != null && Teacher.SignIn(Username, Password))
                {
                    _userService.CurrentUser = Teacher;
                };
            }
        }

        private bool CanSendMessage(object obj)
        {
            return true;
        }

        private void SendMessage(object obj)
        {
            if (CanSendMessage(obj))
            {
                _chatService.CurrentChat.SendMessage(new TextChatMessage(_userService.CurrentUser.Id, Message));
            }
        }

        private bool CanGetTask(object obj)
        {
            return true;
        }

        private void GetTask(object obj)
        {
            if (CanGetTask(obj))
            {
                MessageBox.Show(SelectedCourse.GetTask());
            }
        }

        private bool CanCreateTask(object obj)
        {
            return true;
        }

        private void CreateTask(object obj)
        {
            if (CanSendMessage(obj))
            {
                SelectedCourse.CreateTask(TaskInput, AnswerInput, FacultyInput);
                MessageBox.Show("Created task");
            }
        }

        private bool CanGetChatHistory(object obj)
        {
            return true;
        }

        private void GetChatHistory(object obj)
        {
            if (CanGetChatHistory(obj))
            {
                string chatHistory = "";
                SelectedChat.GetMessages().ToList().ForEach(m => chatHistory += m.Serialize() + "\n");
                MessageBox.Show(chatHistory);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
