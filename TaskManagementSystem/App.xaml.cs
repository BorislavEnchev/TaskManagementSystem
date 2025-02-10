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
        public static IServiceProvider ServiceProvider { get; private set; }

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
            services.AddTransient<TaskViewModel>();    
            services.AddTransient<CommentViewModel>();
            services.AddTransient<TaskCreationViewModel>();
            services.AddTransient<TaskDetailsViewModel>();
            services.AddSingleton<MainViewModel>();

            // Register Views
            services.AddSingleton<MainWindow>();
            services.AddTransient<TaskCreationView>();
            services.AddTransient<TaskDetailsView>();
            services.AddTransient<TaskView>();
            services.AddTransient<CommentView>();

            ServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            }
            catch (Exception ex)
            {
                // Handle any startup errors
                MessageBox.Show($"Failed to start the application: {ex.Message}", "Startup Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown();
            }
        }
    }

}
