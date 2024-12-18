using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class UserManagerViewModel
    {
        public ObservableCollection<User> Users { get; set; }

        public UserManagerViewModel(UserRepository userRepository)
        {
            this.Users = userRepository.GetAllUsers();
        }
    }
}
