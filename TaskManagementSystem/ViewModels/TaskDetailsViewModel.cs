using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TaskManagementSystem.BLL.Interfaces;
using TaskManagementSystem.DAL.Enums;
using TaskManagementSystem.DAL.Models;
using TaskManagementSystem.ViewModels;
using TaskStatus = TaskManagementSystem.DAL.Enums.TaskStatus;

public class TaskDetailsViewModel : BaseViewModel
{
    private readonly ITaskService _taskService;
    private readonly IUserService _userService;
    private readonly ICommentService _commentService;

    public TaskDetailsViewModel(ITaskService taskService, IUserService userService, ICommentService commentService)
    {
        _taskService = taskService;
        _userService = userService;
        _commentService = commentService;

        Users = new ObservableCollection<User>();
        TaskStatuses = new ObservableCollection<TaskStatus>(Enum.GetValues<TaskStatus>());
        TaskTypes = new ObservableCollection<TaskType>(Enum.GetValues<TaskType>());
        Comments = new ObservableCollection<Comment>();

        UpdateTaskCommand = new RelayCommand(async () => await UpdateTask());

        LoadUsersAsync();
    }

    public ObservableCollection<User> Users { get; }
    public ObservableCollection<TaskStatus> TaskStatuses { get; }
    public ObservableCollection<TaskType> TaskTypes { get; }
    public ObservableCollection<Comment> Comments { get; }

    private TaskManagementSystem.DAL.Models.Task _task;
    public TaskManagementSystem.DAL.Models.Task Task
    {
        get => _task;
        set => SetProperty(ref _task, value);
    }

    public IRelayCommand UpdateTaskCommand { get; }

    public async System.Threading.Tasks.Task LoadTaskAsync(int taskId)
    {
        Task = await _taskService.GetTaskByIdAsync(taskId);
        var comments = await _commentService.GetCommentsByTaskIdAsync(taskId);
        Comments.Clear();
        foreach (var comment in comments)
        {
            Comments.Add(comment);
        }
    }

    private async void LoadUsersAsync()
    {
        var users = await _userService.GetAllUsersAsync();
        Users.Clear();
        foreach (var user in users)
        {
            Users.Add(user);
        }
    }

    private async System.Threading.Tasks.Task UpdateTask()
    {
        await _taskService.UpdateTaskAsync(Task);
    }
}
