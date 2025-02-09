using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Windows;
using TaskManagementSystem.BLL.Interfaces;
using TaskManagementSystem.BLL.Services;
using TaskManagementSystem.DAL.Contexts;
using TaskManagementSystem.DAL.Repositories;
using TaskManagementSystem.DAL.Repositories.Interfaces;
using TaskManagementSystem.ViewModels;
using TaskManagementSystem.Views;

namespace TaskManagementSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            string connectionString = ConfigurationManager.ConnectionStrings["TaskManagementDb"].ConnectionString;
            
            services.AddDbContext<TaskManagementContext>(options =>
                options.UseSqlServer(connectionString));

            // Register Repositories
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Register Services (Business Layer)
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserService, UserService>();

            // Register ViewModels
            //services.AddSingleton<TaskViewModel>();
            //services.AddSingleton<CommentViewModel>();

            //services.AddTransient<TaskViewModel>();
            //services.AddTransient<CommentViewModel>();
            //services.AddTransient<TaskView>();
            //services.AddTransient<CommentView>();

            // Register Views
            //services.AddSingleton<MainWindow>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }

}
