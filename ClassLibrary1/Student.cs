using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Student : User
    {
        public int Year;
        public string Faculty;

        public Student(string name, string username, string password, string faculty) : base(name, username, password)
        {
            Faculty = faculty;
        }
    }
}
