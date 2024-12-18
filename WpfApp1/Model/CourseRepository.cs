using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class CourseRepository
    {
        public ObservableCollection<Course> Courses = new ObservableCollection<Course>();

        public CourseRepository()
        {
            Courses.Add(new Course("Course 1"));
            Courses.Add(new Course("Course 2"));
            Courses.Add(new Course("Course 3"));
        }

        public ObservableCollection<Course> GetAllCourses()
        {
            return Courses;
        }

        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }

        public void AddCourseToUser(Course course, User user)
        {
            user.AddCourse(course);
        }

        public ObservableCollection<Course> GetUserCources(User user)
        {
            return new ObservableCollection<Course>(user.Courses);
        }
    }
}
