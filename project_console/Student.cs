using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_console
{
    class Student : User
    {
        public string groupId;
        public string[] chatIds;

        public Student(string name, string username, string password) : base(name, username, password)
        {
        }
    }
}
