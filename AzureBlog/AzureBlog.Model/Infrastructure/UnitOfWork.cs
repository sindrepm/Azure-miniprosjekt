using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AzureBlog.Model.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private AzureBlogContext _dataContext;

        public UnitOfWork(AzureBlogContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public void Commit()
        {
            _dataContext.Commit();
        }
    }
}