using BlogPage.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPage.Core.Services
{
    public interface IBlogService:IService<Blog>
    {
        CustomResponseDTO<List<BlogwithCategoryDTO>> GetBlogwithCategory();
    }
}
