using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskManagementSystem.BLL.Interfaces;
using TaskManagementSystem.DAL.Enums;
using TaskManagementSystem.DAL.Models;
using Task = System.Threading.Tasks.Task;
using TaskStatus = TaskManagementSystem.DAL.Enums.TaskStatus;

namespace TaskManagementSystem.ViewModels
{
    public class TaskCreationViewModel : BaseViewModel
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;

        public TaskCreationViewModel(ITaskService taskService, IUserService userService)
        {
            _taskService = taskService;
            _userService = userService;

            Task<IEnumerable<User>> users = _userService.GetAllUsersAsync();
            Users = new ObservableCollection<User>(/*users*/);
            SaveTaskCommand = new RelayCommand(async () => await SaveTask());
        }

        public ObservableCollection<User> Users { get; set; }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private DateTime _requiredByDate = DateTime.Now;
        public DateTime RequiredByDate
        {
            get => _requiredByDate;
            set => SetProperty(ref _requiredByDate, value);
        }

        private TaskStatus _status;
        public TaskStatus Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        private TaskType _type;
        public TaskType Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        private User _assignedTo;
        public User AssignedTo
        {
            get => _assignedTo;
            set => SetProperty(ref _assignedTo, value);
        }

        public ICommand SaveTaskCommand { get; }

        private async Task SaveTask()
        {
            var newTask = new DAL.Models.Task
            {
                Description = Description,
                RequiredByDate = RequiredByDate,
                Status = Status,
                Type = Type,
                AssignedTo = AssignedTo,
                CreatedDate = DateTime.UtcNow
            };

            await _taskService.CreateTaskAsync(newTask);
        }
    }
}
