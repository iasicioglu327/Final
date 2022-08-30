using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPage.Core.Repositories
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Category GetCategorybyId(int categoryId);
    }
}
