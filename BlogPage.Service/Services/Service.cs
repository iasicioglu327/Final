using BlogPage.Core;
using BlogPage.Core.Repositories;
using BlogPage.Core.Services;
using BlogPage.Core.UnitofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogPage.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly IUnitofWork _work;

        public Service(IRepository<T> repository, IUnitofWork work)
        {
            _repository = repository;
            _work = work;
        }

        public T Add(T entity)
        {
            _repository.Add(entity);
            _work.Commit();
            return entity;
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _work.Commit();
        }

        public T GetbyId(int id)
        {
           return _repository.GetbyId(id);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _work.Commit();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
        public List<T> GetList()
        {
            return _repository.GetList();
        }
    }
}
