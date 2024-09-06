using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_console
{
    public class Administrator : User
    {
        public string[] chatIds;

        public Administrator(string name, string username, string password) : base(name, username, password)
        {
        }

        public void AddStudent(Student student)
        {
            // Code to create a new user
            throw new NotImplementedException();
        }

        public void AddAdministrator(Administrator admin)
        {
            // Code to create a new user
            throw new NotImplementedException();
        }

        public User DeleteUser(string username)
        {
            // Code to delete a user
            throw new NotImplementedException();
        }

        public List<Student> GetStudents()
        {
            // Code to retrieve a list of students
            throw new NotImplementedException();
        }

        public List<Administrator> GetAdministrators()
        {
            // Code to retrieve a list of administrators
            throw new NotImplementedException();
        }

        public void AddGroup(Group group)
        {
            // Code to create a new group
            throw new NotImplementedException();
        }
    }
}
