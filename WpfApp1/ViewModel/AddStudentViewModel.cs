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
    public class AddStudentViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Faculty { get; set; }

        public ICommand AddStudentCommand { get; set; }

        private readonly UserRepository UserRepository;

        public AddStudentViewModel(UserRepository userRepository)
        {
            Username = "";
            Password = "";
            FullName = "";
            Faculty = "";

            AddStudentCommand = new RelayCommand(AddStudent, CanAddStudent);

            UserRepository = userRepository;
        }

        private bool CanAddStudent(object obj)
        {
            return true;
        }

        private void AddStudent(object obj)
        {
            if (CanAddStudent(obj))
            {
                UserRepository.AddUser(new Student(FullName, Username, Password, Faculty));
            }
        }
    }
}
