using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Windows;
using TaskManagementSystem.DAL.Contexts;
using TaskManagementSystem.DAL.Repositories;
using TaskManagementSystem.DAL.Repositories.Interfaces;
//using TaskManagementSystem.BLL.Services;

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

            // Register Services (Business Layer)
            //services.AddScoped<TaskService>();
            //services.AddScoped<CommentService>();

            // Register ViewModels
            //services.AddSingleton<MainWindowViewModel>();
            //services.AddSingleton<TaskViewModel>();
            //services.AddSingleton<CommentViewModel>();

            // Register Views
            services.AddSingleton<MainWindow>();

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
