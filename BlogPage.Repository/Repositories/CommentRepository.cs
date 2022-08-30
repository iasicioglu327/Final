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
    internal class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }

        public List<Comment> GetCommentwithBlog()
        {
            return _context.Comments.Include(x => x.Blog).ToList();
        }
    }
}
