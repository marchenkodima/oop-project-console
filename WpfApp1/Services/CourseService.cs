using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
    public class CourseService : INotifyPropertyChanged
    {
        private Course _currentCourse;
        public Course CurrentCourse
        {
            get => _currentCourse;
            set
            {
                if (_currentCourse != value)
                {
                    _currentCourse = value;
                    OnPropertyChanged(nameof(CurrentCourse));
                }
            }
        }

        private void CurrentUser_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Chat.Messages))
            {
                OnPropertyChanged(nameof(CurrentCourse));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
