using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace AzureBlog.Model.Helper
{
    public static class DbSetExtensions
    {
        public static IDbSet<T> IncludeMultiple<T>(this IDbSet<T> mainQuery, params string[] includeProperties) where T : class
        {
            if (includeProperties != null)
            {
                foreach (var property in includeProperties)
                {
                    mainQuery.Include(property);
                }
            }

            return mainQuery;
        }
    }
}