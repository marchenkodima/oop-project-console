using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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
        ObservableCollection<Chat> Chats { get; set; }

        ObservableCollection<Course> Courses { get; set; }

        bool SignIn(string username, string password);
        void AddChat(Chat chat);
    }

    public class User : IUser, ICloneable, INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Username { get; set; }
        private string Password { get; set; }
        public string Id { get; set; }
        private ObservableCollection<Chat> _chats;
        public ObservableCollection<Chat> Chats
        {
            get => _chats;
            set
            {
                if (_chats != value)
                {
                    _chats = value;
                    OnPropertyChanged(nameof(Chats));
                }
            }
        }
        private ObservableCollection<Course> _courses;
        public ObservableCollection<Course> Courses
        {
            get => _courses;
            set
            {
                if (_courses != value)
                {
                    _courses = value;
                    OnPropertyChanged(nameof(Courses));
                }
            }
        }

        public User(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = password;
            Chats = new ObservableCollection<Chat>();
            Courses = new ObservableCollection<Course>();
            Id = Guid.NewGuid().ToString();

            Courses.CollectionChanged += Courses_CollectionChanged;
            Chats.CollectionChanged += Chats_CollectionChanged;
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

        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        private void Courses_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Notify that the Courses property has changed whenever the collection is modified
            OnPropertyChanged(nameof(Courses));
        }

        private void Chats_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Notify that the Courses property has changed whenever the collection is modified
            OnPropertyChanged(nameof(Chats));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
