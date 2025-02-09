using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TaskManagementSystem.BLL.Interfaces;
using TaskManagementSystem.DAL.Enums;
using TaskManagementSystem.DAL.Models;
using Task = System.Threading.Tasks.Task;

namespace TaskManagementSystem.ViewModels
{
    public class CommentViewModel : BaseViewModel
    {
        private readonly ICommentService _commentService;

        public CommentViewModel(ICommentService commentService)
        {
            _commentService = commentService;
            Comments = new ObservableCollection<Comment>();
            AddCommentCommand = new AsyncRelayCommand(AddComment);
            UpdateCommentCommand = new AsyncRelayCommand(UpdateComment);
            DeleteCommentCommand = new AsyncRelayCommand(DeleteComment);
            LoadCommentsCommand = new AsyncRelayCommand(LoadComments);
        }

        public ObservableCollection<Comment> Comments { get; set; }

        private Comment _selectedComment;
        public Comment SelectedComment
        {
            get => _selectedComment;
            set => SetProperty(ref _selectedComment, value);
        }

        private int _taskId;
        public int TaskId
        {
            get => _taskId;
            set => SetProperty(ref _taskId, value);
        }

        public IAsyncRelayCommand AddCommentCommand { get; }
        public IAsyncRelayCommand UpdateCommentCommand { get; }
        public IAsyncRelayCommand DeleteCommentCommand { get; }
        public IAsyncRelayCommand LoadCommentsCommand { get; }

        private async Task LoadComments()
        {
            var comments = await _commentService.GetCommentsByTaskIdAsync(TaskId);
            Comments.Clear();
            foreach (var comment in comments) Comments.Add(comment);
        }

        private async Task AddComment()
        {
            var newComment = new Comment
            {
                TaskId = TaskId,
                Content = "New Comment",
                Type = CommentType.General,
                ReminderDate = null
            };
            await _commentService.AddCommentAsync(newComment);
            await LoadComments();
        }

        private async Task UpdateComment()
        {
            if (SelectedComment != null)
            {
                await _commentService.UpdateCommentAsync(SelectedComment);
                await LoadComments();
            }
        }

        private async Task DeleteComment()
        {
            if (SelectedComment != null)
            {
                await _commentService.DeleteCommentAsync(SelectedComment.Id);
                await LoadComments();
            }
        }
    }
}