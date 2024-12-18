using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class UserRepository
    {
        public ObservableCollection<User> Users = new ObservableCollection<User>();

        public UserRepository()
        {
            // Generate 3 mock users
            Users.Add(new Student("John", "Doe", "123", "1"));
            Users.Add(new Student("Jane", "Smith", "123", "1"));
            Users.Add(new Student("Mike", "Johnson", "123", "2"));
            Users.Add(new Teacher("Alice", "Brown", "123"));
        }

        public ObservableCollection<User> GetAllUsers()
        {
            return Users;
        }

        public Student GetStudentByUsername(string username)
        {
            return Users.OfType<Student>().FirstOrDefault((student) => student.Username == username);
        }

        public Teacher GetTeacherByUsername(string username)
        {
            return Users.OfType<Teacher>().FirstOrDefault((teacher) => teacher.Username == username);
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }
    }
}
