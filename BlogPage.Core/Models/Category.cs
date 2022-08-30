using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPage.Core
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName{ get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
