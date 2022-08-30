using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPage.Core.DTOs
{
    public class BlogwithCategoryDTO:BlogDTO
    {
        public CategoryDTO Category { get; set; }   
    }
}
