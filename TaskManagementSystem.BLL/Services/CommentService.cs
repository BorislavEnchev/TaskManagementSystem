using TaskManagementSystem.DAL.Models;
using TaskManagementSystem.DAL.Repositories.Interfaces;
using TaskManagementSystem.BLL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace TaskManagementSystem.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task AddCommentAsync(Comment comment)
        {
            await _commentRepository.AddAsync(comment);
            await _commentRepository.SaveChangesAsync();
        }

        public async Task<int> AddCommentWithIdAsync(Comment comment)
        {
            try
            {
                await AddCommentAsync(comment);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return comment.Id;
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            _commentRepository.Update(comment);
            await _commentRepository.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            var comment = await _commentRepository.GetByIdAsync(commentId);
            if (comment != null)
            {
                _commentRepository.Delete(comment);
                await _commentRepository.SaveChangesAsync();
            }
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            return await _commentRepository.GetByIdAsync(commentId);
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync()
        {
            return await _commentRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsByTaskIdAsync(int taskId)
        {
            return await _commentRepository.GetCommentsByTaskIdAsync(taskId);
        }
    }
}
