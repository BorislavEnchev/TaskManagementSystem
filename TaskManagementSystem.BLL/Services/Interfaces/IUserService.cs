using TaskManagementSystem.DAL.Models;
using Task = System.Threading.Tasks.Task;

namespace TaskManagementSystem.BLL.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
        Task<User> GetUserByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
