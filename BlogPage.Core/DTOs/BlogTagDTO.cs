using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPage.Core.DTOs
{
    public class BlogTagDTO: TagDTO
    {
        public List<BlogDTO> Blogs { get; set;}
    }
}
