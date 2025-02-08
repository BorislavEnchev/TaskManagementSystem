using TaskManagementSystem.DAL.Enums;

namespace TaskManagementSystem.DAL.Models
{
    public class Task
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime RequiredByDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public Enums.TaskStatus Status { get; set; }
        public TaskType Type { get; set; }
        public int AssignedToId { get; set; }
        public User AssignedTo { get; set; } = null!;
        public DateTime? NextActionDate { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
