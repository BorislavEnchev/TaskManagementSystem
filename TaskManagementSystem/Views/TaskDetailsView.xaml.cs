using System.Windows;

namespace TaskManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for TaskDetailsView.xaml
    /// </summary>
    public partial class TaskDetailsView : Window
    {
        public TaskDetailsView(TaskDetailsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
