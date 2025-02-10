using Microsoft.Extensions.DependencyInjection;
using System.Windows;
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

        private async void ListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var viewModel = DataContext as TaskViewModel;
            if (viewModel?.SelectedTask != null)
            {
                // Resolve TaskDetailsViewModel from the DI container
                var taskDetailsViewModel = App.ServiceProvider.GetRequiredService<TaskDetailsViewModel>();

                // Load the selected task details
                await taskDetailsViewModel.LoadTaskAsync(viewModel.SelectedTask.Id);

                // Resolve and show the TaskDetailsView
                var taskDetailsView = new TaskDetailsView(taskDetailsViewModel);
                taskDetailsView.Show();
            }
        }
    }
}