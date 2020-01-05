using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
