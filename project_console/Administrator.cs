using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_console
{
    class Administrator : User
    {
        public string[] chatIds;

        public Administrator(string name, string username, string password) : base(name, username, password)
        {
        }

        public void CreateUser(string name, string username, string password)
        {
            // Code to create a new user
            throw new NotImplementedException();
        }

        public void DeleteUser(string username)
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

        public void CreateGroup(string[] studentIds)
        {
            // Code to create a new group
            throw new NotImplementedException();
        }
    }
}
