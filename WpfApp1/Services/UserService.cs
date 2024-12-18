using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
    public class UserService : INotifyPropertyChanged
    {
        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                if (_currentUser != value)
                {
                    if (_currentUser != null)
                    {
                        _currentUser.PropertyChanged -= CurrentUser_PropertyChanged;
                    }

                    _currentUser = value;

                    if (_currentUser != null)
                    {
                        _currentUser.PropertyChanged += CurrentUser_PropertyChanged;
                    }

                    OnPropertyChanged(nameof(CurrentUser));
                }
            }
        }

        private void CurrentUser_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(User.Courses) || e.PropertyName == nameof(User.Chats))
            {
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
