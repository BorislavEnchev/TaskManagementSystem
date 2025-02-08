using TaskManagementSystem.DAL.Enums;

namespace TaskManagementSystem.DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; } = null!;
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public string Content { get; set; } = string.Empty;
        public CommentType Type { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool IsEditable { get; set; } = true;
    }
}
