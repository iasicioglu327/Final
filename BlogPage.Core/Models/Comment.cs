using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPage.Core
{
    public class Comment
    {
        public int ID { get; set; }
        public string CommentContent { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
