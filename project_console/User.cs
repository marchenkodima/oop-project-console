using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_console
{
    interface IUser
    {
        string Name { get; set; }
        string Username { get; set; }
        int Id { get; set; }
        bool SignIn(string username, string password);
    }

    class User : IUser
    {
        public string Name { get; set; }
        public string Username { get; set; }
        private string Password { get; set; }
        public int Id { get; set; }

        public User(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = password;
        }

        public bool SignIn(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
