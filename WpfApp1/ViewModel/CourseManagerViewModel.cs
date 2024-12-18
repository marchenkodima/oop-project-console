using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
    public class CourseManagerViewModel : INotifyPropertyChanged
    {
        public string CourseName { get; set; }

        private readonly UserService _studentService;
        private readonly UserService _teacherService;
        private readonly CourseService _courseService;

        private Course _SelectedCourse;
        public Course SelectedCourse {
            get
            {
                return _courseService.CurrentCourse;
            }
            set
            {
                _courseService.CurrentCourse = value;
            }
        }

        private Student _SelectedStudent;
        public Student SelectedStudent
        {
            get
            {
                return _studentService.CurrentUser as Student;
            }
            set
            {
                _studentService.CurrentUser = value;
            }
        }

        private Teacher _SelectedTeacher;
        public Teacher SelectedTeacher
        {
            get
            {
                return _teacherService.CurrentUser as Teacher;
            }
            set
            {
                _teacherService.CurrentUser = value;
            }
        }
        public ObservableCollection<Course> Courses { get; set; }
        public ICollectionView Students { get; set; }
        public ICollectionView Teachers { get; set; }
        public ICollectionView CourseStudents { get; set; }
        public ICollectionView CourseTeachers { get; set; }

        private CourseRepository CourseRepository;
        private UserRepository UserRepository;

        public ICommand AddCourseCommand { get; set; }
        public ICommand AddStudentToCourseCommand { get; set; }
        public ICommand AddTeacherToCourseCommand { get; set; }

        public CourseManagerViewModel(CourseRepository courseRepository, UserRepository userRepository)
        {
            _studentService = new UserService();
            _teacherService = new UserService();
            _courseService = new CourseService();

            _studentService.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(UserService.CurrentUser))
                {
                    OnPropertyChanged(nameof(CourseStudents));
                }
            };
            _teacherService.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(UserService.CurrentUser))
                {
                    OnPropertyChanged(nameof(CourseTeachers));
                }
            };
            _courseService.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(CourseService.CurrentCourse))
                {
                    OnPropertyChanged(nameof(CourseStudents));
                    OnPropertyChanged(nameof(CourseTeachers));
                }
            };

            Courses = courseRepository.GetAllCourses();

            Students = new ListCollectionView(userRepository.GetAllUsers());
            Students.Filter = (obj) => obj is Student;
            Teachers = new ListCollectionView(userRepository.GetAllUsers());
            Teachers.Filter = (obj) => obj is Teacher;

            CourseStudents = new ListCollectionView(userRepository.GetAllUsers());
            CourseStudents.Filter = (obj) => obj is Student student && student.Courses.Contains(SelectedCourse);
            CourseTeachers = new ListCollectionView(userRepository.GetAllUsers());
            CourseTeachers.Filter = (obj) => obj is Teacher teacher && teacher.Courses.Contains(SelectedCourse);

            CourseRepository = courseRepository;
            UserRepository = userRepository;

            AddCourseCommand = new RelayCommand(AddCourse, CanAddCourse);
            AddStudentToCourseCommand = new RelayCommand(AddStudentToCourse, CanAddStudentToCourse);
            AddTeacherToCourseCommand = new RelayCommand(AddTeacherToCourse, CanAddTeacherToCourse);
        }

        private bool CanAddCourse(object obj)
        {
            return true;
        }

        private void AddCourse(object obj)
        {
            if (CanAddCourse(obj))
            {
                CourseRepository.AddCourse(new Course(CourseName));
            }
        }

        private bool CanAddStudentToCourse(object obj)
        {
            return true;
        }

        private void AddStudentToCourse(object obj)
        {
            if (CanAddStudentToCourse(obj))
            {
                SelectedStudent.AddCourse(SelectedCourse);
            }
        }

        private bool CanAddTeacherToCourse(object obj)
        {
            return true;
        }

        private void AddTeacherToCourse(object obj)
        {
            bool isCourseAssignedToTeacher = UserRepository.Users.Any((user) => user is Teacher && user.Courses.Contains(SelectedCourse));
            if (CanAddTeacherToCourse(obj) && !isCourseAssignedToTeacher)
            {
                SelectedTeacher.AddCourse(SelectedCourse);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (propertyName == nameof(CourseStudents)) CourseStudents.Refresh();
            if (propertyName == nameof(CourseTeachers)) CourseTeachers.Refresh();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
