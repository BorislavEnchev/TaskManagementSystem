using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using TaskManagementSystem.Views;

namespace TaskManagementSystem.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IServiceProvider _serviceProvider;

        public IRelayCommand OpenTaskViewCommand { get; }
        public IRelayCommand OpenCommentViewCommand { get; }
        public IRelayCommand OpenSearchViewCommand { get; }
        public IRelayCommand LogoutCommand { get; }

        public MainViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            OpenTaskViewCommand = new RelayCommand(OpenTaskView);
            OpenCommentViewCommand = new RelayCommand(OpenCommentView);
            OpenSearchViewCommand = new RelayCommand(OpenSearchView);
            LogoutCommand = new RelayCommand(Logout);
        }

        private void OpenTaskView()
        {
            var taskViewModel = _serviceProvider.GetRequiredService<TaskViewModel>();
            var taskView = new TaskView(taskViewModel);
            taskView.Show();
        }

        private void OpenCommentView()
        {
            var commentViewModel = _serviceProvider.GetRequiredService<CommentViewModel>();
            var commentView = new CommentView(commentViewModel);
            commentView.Show();
        }

        private void OpenSearchView()
        {
            MessageBox.Show("Search functionality not implemented yet!");
        }

        private void Logout()
        {
            Application.Current.Shutdown(); // Closes the app
        }
    }
}