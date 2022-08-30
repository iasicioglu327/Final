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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public Category GetCategorybyId(int categoryId)
        {
            return _context.Categories.Include(x=>x.Blogs).Where(x=>x.ID == categoryId).SingleOrDefault();
        }
    }
}
