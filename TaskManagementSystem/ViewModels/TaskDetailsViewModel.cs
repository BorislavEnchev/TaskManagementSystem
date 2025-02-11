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
        FilteredComments = new ObservableCollection<Comment>(Comments);

        SearchCommentsCommand = new RelayCommand(UpdateFilteredComments);
        UpdateTaskCommand = new RelayCommand(async () => await UpdateTask());
        DeleteCommentCommand = new RelayCommand<Comment>(async (comment) => await DeleteComment(comment));

        LoadUsersAsync();
    }

    public ObservableCollection<User> Users { get; }
    public ObservableCollection<TaskStatus> TaskStatuses { get; }
    public ObservableCollection<TaskType> TaskTypes { get; }
    public ObservableCollection<Comment> Comments { get; }

    private ObservableCollection<Comment> _filteredComments;
    public ObservableCollection<Comment> FilteredComments
    {
        get => _filteredComments ??= new ObservableCollection<Comment>();
        set => SetProperty(ref _filteredComments, value);
    }

    private TaskManagementSystem.DAL.Models.Task _task;
    public TaskManagementSystem.DAL.Models.Task Task
    {
        get => _task;
        set => SetProperty(ref _task, value);
    }

    private string _newCommentContent;
    public string NewCommentContent
    {
        get => _newCommentContent;
        set => SetProperty(ref _newCommentContent, value);
    }

    private string _searchText;
    public string SearchText
    {
        get => _searchText;
        set
        {
            if (SetProperty(ref _searchText, value))
            {
                UpdateFilteredComments();
            }
        }
    }

    public IRelayCommand SearchCommentsCommand { get; }
    public IRelayCommand DeleteCommentCommand { get; }
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
        UpdateFilteredComments();
    }

    private async System.Threading.Tasks.Task DeleteComment(Comment comment)
    {
        if (comment != null)
        {
            await _commentService.DeleteCommentAsync(comment.Id);
            Comments.Remove(comment);
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
        UpdateFilteredComments();
    }

    private void UpdateFilteredComments()
    {
        if (string.IsNullOrWhiteSpace(SearchText))
        {
            FilteredComments = new ObservableCollection<Comment>(Comments);
        }
        else
        {
            var searchTextLower = SearchText.ToLower();
            FilteredComments = new ObservableCollection<Comment>(Comments.Where(c =>
                c.Content.ToLower().Contains(searchTextLower)));
        }
    }

    private async System.Threading.Tasks.Task UpdateTask()
    {
        await _taskService.UpdateTaskAsync(Task);

        if (!string.IsNullOrWhiteSpace(NewCommentContent))
        {
            var newComment = new Comment
            {
                TaskId = Task.Id,
                Content = NewCommentContent,
                Type = CommentType.General,
                DateAdded = DateTime.UtcNow,
                IsEditable = true
            };

            await _commentService.AddCommentAsync(newComment);
            Comments.Add(newComment);
            NewCommentContent = string.Empty; 
        }

        foreach (var comment in Comments)
        {
            await _commentService.UpdateCommentAsync(comment);
        }

        // Reload comments (optional, if you want to refresh the list)
        var comments = await _commentService.GetCommentsByTaskIdAsync(Task.Id);
        Comments.Clear();
        foreach (var comment in comments)
        {
            Comments.Add(comment);
        }
    }
}