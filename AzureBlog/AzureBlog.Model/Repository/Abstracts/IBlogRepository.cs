using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AzureBlog.Model.Infrastructure;
using AzureBlog.Model.Entities;

namespace AzureBlog.Model.Repository.Abstracts
{
    public interface IBlogRepository : IRepository<BlogPost>
    {
        
    }
}