using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq.Expressions;
using AzureBlog.Model.Helper;


namespace AzureBlog.Model.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private AzureBlogContext _dataContext;
        private readonly IDbSet<T> _dbSet;

        protected RepositoryBase(AzureBlogContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = dataContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dataContext.Entry(entity).State = System.Data.EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> entities = _dbSet.Where(where).AsEnumerable();

            foreach (var item in entities)
            {
                _dbSet.Remove(item);
            }
        }

        public T GetById(long id, params string[] includes)
        {
            return _dbSet.IncludeMultiple(includes).Find(id);
        }

        public T GetById(string id, params string[] includes)
        {
            return _dbSet.IncludeMultiple(includes).Find(id);
        }

        public T Get(Expression<Func<T, bool>> where, params string[] includes)
        {
            return _dbSet.IncludeMultiple(includes).Where(where).FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params string[] includes)
        {
            var query = _dbSet.IncludeMultiple(includes);

            if (orderBy != null)
                return orderBy(query).ToList();

            return _dbSet.ToList();
        }

        public IEnumerable<T> GetMany(Func<T, bool> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params string[] includes)
        {
            var query = _dbSet.IncludeMultiple(includes);

            if (orderBy != null)
                return orderBy(query).ToList();

            return query.ToList();
        }
    }
}