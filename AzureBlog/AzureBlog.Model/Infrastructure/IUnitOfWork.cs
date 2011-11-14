using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureBlog.Model.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}