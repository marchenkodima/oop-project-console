using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for StudentPortal.xaml
    /// </summary>
    public partial class StudentPortal : UserControl
    {
        public StudentPortal()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<StudentPortalViewModel>();
        }
    }
}
