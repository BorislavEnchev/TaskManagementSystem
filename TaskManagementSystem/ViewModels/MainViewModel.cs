﻿using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using TaskManagementSystem.Views;

namespace TaskManagementSystem.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IServiceProvider _serviceProvider;

        public IRelayCommand OpenTaskCreationViewCommand { get; }
        public IRelayCommand OpenTaskViewCommand { get; }
        public IRelayCommand OpenCommentViewCommand { get; }
        public IRelayCommand OpenSearchViewCommand { get; }
        public IRelayCommand LogoutCommand { get; }

        public MainViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            OpenTaskViewCommand = new RelayCommand(OpenTaskView);
            LogoutCommand = new RelayCommand(Logout);
            OpenTaskCreationViewCommand = new RelayCommand(OpenTaskCreationView);
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

        private void Logout()
        {
            Application.Current.Shutdown();
        }
    }
}