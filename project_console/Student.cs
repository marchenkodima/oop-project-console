using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_console
{
    public class Student : User
    {
        public string groupId;
        public string[] chatIds;

        public Student(string name, string username, string password) : base(name, username, password)
        {
        }

        public SupportChat ContactSupport()
        {
            throw new NotImplementedException();
        }
    }
}
