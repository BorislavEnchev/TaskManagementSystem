using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using TaskManagementSystem.DAL.Contexts;
using TaskManagementSystem.DAL.Models;
using TaskManagementSystem.Views;

namespace TaskManagementSystem.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IServiceProvider _serviceProvider;

        public IRelayCommand OpenTaskCreationViewCommand { get; }
        public IRelayCommand OpenTaskViewCommand { get; }
        public IRelayCommand LogoutCommand { get; }
        public IRelayCommand CreateTestUserCommand { get; }

        public MainViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            OpenTaskViewCommand = new RelayCommand(OpenTaskView);
            LogoutCommand = new RelayCommand(Logout);
            OpenTaskCreationViewCommand = new RelayCommand(OpenTaskCreationView);
            CreateTestUserCommand = new RelayCommand(CreateTestUser);
        }

        private void OpenTaskCreationView()
        {
            var taskCreationModel = _serviceProvider.GetRequiredService<TaskCreationViewModel>();
            var taskCreationView = new TaskCreationView(taskCreationModel);
            taskCreationView.Show();
        }

        private void OpenTaskView()
        {
            var taskViewModel = _serviceProvider.GetRequiredService<TaskViewModel>();
            var taskView = new TaskView(taskViewModel);
            taskView.Show();
        }

        // This method makes easy to create a user for testing purposes
        private void CreateTestUser()
        {
            var dbContext = _serviceProvider.GetRequiredService<TaskManagementContext>();

            var testUser = new User { Name = "Test User" };

            dbContext.Users.Add(testUser);
            dbContext.SaveChanges();

            MessageBox.Show("Test User created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Logout()
        {
            Application.Current.Shutdown();
        }
    }
}