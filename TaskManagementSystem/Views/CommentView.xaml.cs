using System.Windows;
using TaskManagementSystem.ViewModels;

namespace TaskManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for CommentView.xaml
    /// </summary>
    public partial class CommentView : Window
    {
        public CommentView(CommentViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;    
        }
    }
}
