using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace AzureBlog.Model.Infrastructure
{
    public interface ISpecification<TEntity>
    {
        Expression<Func<TEntity, bool>> Predicate { get; }

        bool isSatisfiedBy(TEntity entity);
    }
}