using System.Windows;
using TaskManagementSystem.ViewModels;

namespace TaskManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for TaskView.xaml
    /// </summary>
    public partial class TaskView : Window
    {
        public TaskView(TaskViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
