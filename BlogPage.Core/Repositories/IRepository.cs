using System.Linq.Expressions;

namespace BlogPage.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetbyId(int id);
        IQueryable<T> Where(Expression<Func<T,bool>> expression);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetList();
    }
}
