using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogPage.Core.Services
{
    public interface IService<T> where T : class
    {
        T GetbyId(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetList();
    }
}
