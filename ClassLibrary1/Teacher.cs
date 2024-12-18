using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Teacher : User
    {

        public Teacher(string name, string username, string password) : base(name, username, password)
        {
        }
    }
}
