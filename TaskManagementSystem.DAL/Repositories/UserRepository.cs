using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.DAL.Contexts;
using TaskManagementSystem.DAL.Models;
using TaskManagementSystem.DAL.Repositories.Interfaces;

namespace TaskManagementSystem.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly TaskManagementContext _context;

        public UserRepository(TaskManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
