using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_console
{
    public class Teacher : User
    {
        public List<Course> Courses;

        public Teacher(string name, string username, string password) : base(name, username, password)
        {
            throw new NotImplementedException();
        }
    }
}
