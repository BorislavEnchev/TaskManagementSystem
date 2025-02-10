using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TaskManagementSystem.BLL.Interfaces;
using TaskManagementSystem.DAL.Enums;
using TaskManagementSystem.DAL.Models;
using Task = System.Threading.Tasks.Task;
using TaskStatus = TaskManagementSystem.DAL.Enums.TaskStatus;

namespace TaskManagementSystem.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;
        public TaskViewModel(ITaskService taskService, IUserService userService)
        {
            _taskService = taskService;
            _userService = userService;

            Tasks = new ObservableCollection<DAL.Models.Task>();
            Users = new ObservableCollection<User>();
            Statuses = new ObservableCollection<TaskStatus>(Enum.GetValues(typeof(TaskStatus)).Cast<TaskStatus>());
            Types = new ObservableCollection<TaskType>(Enum.GetValues(typeof(TaskType)).Cast<TaskType>());

            LoadTasksCommand = new AsyncRelayCommand(LoadTasksAsync);
            CreateTaskCommand = new AsyncRelayCommand(CreateTaskAsync);
            UpdateTaskCommand = new AsyncRelayCommand(UpdateTaskAsync);
            DeleteTaskCommand = new AsyncRelayCommand(DeleteTaskAsync);
            LoadUsersCommand = new AsyncRelayCommand(LoadUsersAsync);
        }

        public ObservableCollection<DAL.Models.Task> Tasks { get; set; } = new ObservableCollection<DAL.Models.Task>();
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        public ObservableCollection<TaskStatus> Statuses { get; set; } = new ObservableCollection<TaskStatus>();
        public ObservableCollection<TaskType> Types { get; set; } = new ObservableCollection<TaskType>();


        private DAL.Models.Task _selectedTask;
        public DAL.Models.Task SelectedTask
        {
            get => _selectedTask;
            set => SetProperty(ref _selectedTask, value);
        }

        public IAsyncRelayCommand LoadTasksCommand { get; }
        public IAsyncRelayCommand CreateTaskCommand { get; }
        public IAsyncRelayCommand UpdateTaskCommand { get; }
        public IAsyncRelayCommand DeleteTaskCommand { get; }
        public IAsyncRelayCommand LoadUsersCommand { get; }

        private async Task LoadTasksAsync()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            Tasks.Clear();
            foreach (var task in tasks) Tasks.Add(task);
        }

        private async Task CreateTaskAsync()
        {
            var newTask = new DAL.Models.Task
            {
                CreatedDate = DateTime.Now,
                RequiredByDate = DateTime.Now.AddDays(14), 
                Description = "Test Task",
                Status = TaskStatus.New,
                Type = TaskType.Other,
                AssignedToId = Users.FirstOrDefault()?.Id ?? 1,
                NextActionDate = DateTime.Now
            };
            await _taskService.CreateTaskAsync(newTask);
            await LoadTasksAsync();
        }

        private async Task UpdateTaskAsync()
        {
            if (SelectedTask != null)
            {
                await _taskService.UpdateTaskAsync(SelectedTask);
                await LoadTasksAsync();
            }
        }

        private async Task DeleteTaskAsync()
        {
            if (SelectedTask != null)
            {
                await _taskService.DeleteTaskAsync(SelectedTask.Id);
                await LoadTasksAsync();
            }
        }

        private async Task LoadUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            Users.Clear();
            foreach (var user in users) Users.Add(user);
        }
    }
}