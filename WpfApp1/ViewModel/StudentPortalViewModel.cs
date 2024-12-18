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
    public class StudentPortalViewModel : INotifyPropertyChanged
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public string TaskAnswer { get; set; }

        private readonly UserService _userService;
        private readonly ChatService _chatService;

        public ObservableCollection<Course> StudentCourses => _userService.CurrentUser?.Courses;
        public ObservableCollection<Chat> StudentChats => _userService.CurrentUser?.Chats;
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
        public ICommand GetTaskCommand { get; set; }
        public ICommand SubmitTaskCommand { get; set; }

        private readonly UserRepository UserRepository;
        private readonly ChatRepository ChatRepository;

        public StudentPortalViewModel(UserRepository userRepository, ChatRepository chatRepository)
        {
            Username = "";
            Password = "";
            SignInCommand = new RelayCommand(SignIn, CanSignIn);
            SendMessageCommand = new RelayCommand(SendMessage, CanSendMessage);
            GetTaskCommand = new RelayCommand(GetTask, CanGetTask);
            SubmitTaskCommand = new RelayCommand(SubmitTask, CanSubmitTask);
            UserRepository = userRepository;
            ChatRepository = chatRepository;

            _userService = new UserService();
            _userService.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(UserService.CurrentUser))
                {
                    OnPropertyChanged(nameof(StudentCourses));
                    OnPropertyChanged(nameof(StudentChats));
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
                var Student = UserRepository.GetStudentByUsername(Username);
                if (Student != null && Student.SignIn(Username, Password))
                {
                    _userService.CurrentUser = Student;
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

        private bool CanSubmitTask(object obj)
        {
            return true;
        }

        private void SubmitTask(object obj)
        {
            if (CanSendMessage(obj))
            {
                bool res = SelectedCourse.SubmitTask(TaskAnswer, _userService.CurrentUser as Student);
                if (res)
                {
                    MessageBox.Show("Correct");
                } else
                {
                    MessageBox.Show("Incorrect");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
