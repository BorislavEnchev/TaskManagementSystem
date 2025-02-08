using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.DAL.Models;

namespace TaskManagementSystem.DAL.Contexts
{
    public class TaskManagementContext : DbContext
    {
        public TaskManagementContext(DbContextOptions<TaskManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
