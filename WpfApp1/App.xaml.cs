using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WpfApp1.Model;
using WpfApp1.Services;
using WpfApp1.View;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Configure DI
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            // Start MainWindow
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Register ViewModels
            services.AddTransient<UserManagerViewModel>();
            services.AddTransient<AddStudentViewModel>();
            services.AddTransient<AddTeacherViewModel>();
            services.AddTransient<ChatManagerViewModel>();
            services.AddTransient<StudentPortalViewModel>();
            services.AddTransient<CourseManagerViewModel>();
            services.AddTransient<TeacherPortalViewModel>();

            // Register other services
            services.AddSingleton<UserRepository>();
            services.AddSingleton<ChatRepository>();
            services.AddSingleton<CourseRepository>();
        }
    }
}
