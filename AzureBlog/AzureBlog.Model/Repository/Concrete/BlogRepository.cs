using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AzureBlog.Model.Infrastructure;
using AzureBlog.Model.Entities;
using AzureBlog.Model.Repository.Abstracts;

namespace AzureBlog.Model.Repository.Concrete
{
    public class BlogRepository : RepositoryBase<BlogPost>, IBlogRepository
    {
        public BlogRepository(AzureBlogContext dataContext) : base(dataContext)
        {

        }
    }
}