using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Teacher : User
    {
        public List<Course> Courses;

        public Teacher(string name, string username, string password) : base(name, username, password)
        {
            Courses = new List<Course>();
        }
    }
}
