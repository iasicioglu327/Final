using Microsoft.EntityFrameworkCore;

namespace BlogPage.Repository.Repositories
{
    public class RepositoryBase<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
    }
}