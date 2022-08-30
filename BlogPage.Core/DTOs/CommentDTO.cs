using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPage.Core.DTOs
{
    public class CommentDTO
    {
        public int ID { get; set; }
        public string CommentContent { get; set; }
        public int BlogId { get; set; }
    }
}
