using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPage.Core.DTOs
{
    public class BlogDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
    }
}
