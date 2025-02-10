using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Input;
using TaskManagementSystem.ViewModels;

namespace TaskManagementSystem.Views
{
    public partial class TaskView : Window
    {
        public TaskView(TaskViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        // Handle double-click event
        private async void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            await OpenTaskDetailsViewAsync();
        }

        // Method to open TaskDetailsView asynchronously
        private async Task OpenTaskDetailsViewAsync()
        {
            var viewModel = DataContext as TaskViewModel;
            if (viewModel?.SelectedTask != null)
            {
                // Resolve TaskDetailsViewModel from the DI container
                var taskDetailsViewModel = App.ServiceProvider.GetRequiredService<TaskDetailsViewModel>();

                // Load the selected task details asynchronously
                await taskDetailsViewModel.LoadTaskAsync(viewModel.SelectedTask.Id);

                // Resolve and show the TaskDetailsView
                var taskDetailsView = new TaskDetailsView(taskDetailsViewModel);
                taskDetailsView.Show();
            }
        }
    }
}