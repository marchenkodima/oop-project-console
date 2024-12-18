using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class AddTeacherViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public ICommand AddTeacherCommand { get; set; }

        private readonly UserRepository UserRepository;

        public AddTeacherViewModel(UserRepository userRepository)
        {
            Username = "";
            Password = "";
            FullName = "";

            AddTeacherCommand = new RelayCommand(AddTeacher, CanAddTeacher);

            UserRepository = userRepository;
        }

        private bool CanAddTeacher(object obj)
        {
            return true;
        }

        private void AddTeacher(object obj)
        {
            if (CanAddTeacher(obj))
            {
                UserRepository.AddUser(new Teacher(FullName, Username, Password));
            }
        }
    }
}
