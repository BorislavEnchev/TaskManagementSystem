using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TaskManagementSystem.DAL.Contexts;

namespace TaskManagementSystem.DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TaskManagementContext>
    {
        public TaskManagementContext CreateDbContext(string[] args)
        {
            // Usually Setting environment variable
            var connectionString = "Server=localhost;Database=TaskManagementDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

            var optionsBuilder = new DbContextOptionsBuilder<TaskManagementContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new TaskManagementContext(optionsBuilder.Options);
        }
    }
}
