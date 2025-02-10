using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.DAL.Contexts;
using TaskManagementSystem.DAL.Models;
using TaskManagementSystem.DAL.Repositories.Interfaces;

namespace TaskManagementSystem.DAL.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly TaskManagementContext _context;

        public CommentRepository(TaskManagementContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Comment>> GetCommentsByTaskIdAsync(int taskId)
        {
            return await _context.Comments
                .Where(c => c.TaskId == taskId)
                .ToListAsync();
        }
    }
}
