using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_console
{
    public class Student : User
    {
        public int Year;
        public string Faculty;
        public List<Course> Courses;

        public Student(string name, string username, string password) : base(name, username, password)
        {
            Courses = new List<Course>();
        }
    }
}
