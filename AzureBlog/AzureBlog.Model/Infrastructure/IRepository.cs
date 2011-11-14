using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace AzureBlog.Model.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        
        void Update(T entity);
        
        void Delete(T entity);
        
        void Delete(Expression<Func<T, bool>> where);
        
        T GetById(long id, params string[] includes);
        
        T GetById(string id, params string[] includes);
        
        T Get(Expression<Func<T, bool>> where, params string[] includes);
        
        IEnumerable<T> GetAll(
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            params string[] includes
        );
        
        IEnumerable<T> GetMany(
            Func<T, bool> where, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            params string[] includes
        );
    }
}