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
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }

        public List<Tag> GetBlogTag()
        {
            return _context.Tags.Include(x => x.Blogs).ToList();
        }
       
    }
}
