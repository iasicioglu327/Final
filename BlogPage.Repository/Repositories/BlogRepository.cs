using BlogPage.Core;
using BlogPage.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPage.Repository.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext context) : base(context)
        {
        }

        public List<Blog> GetBlogwithCategory()
        {
            return _context.Blogs.Include(x=>x.Category).ToList();
        }
    }
}
