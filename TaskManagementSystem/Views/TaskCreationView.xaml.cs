using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TaskManagementSystem.ViewModels;

namespace TaskManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for TaskCreationView.xaml
    /// </summary>
    public partial class TaskCreationView : Window
    {
        public TaskCreationView(TaskCreationViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
