using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AzureBlog.Model.Infrastructure;
using AzureBlog.Model.Repository.Abstracts;
using AzureBlog.Model.Entities;

namespace AzureBlog.Model.Repository.Concrete
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(AzureBlogContext dataContext) : base(dataContext)
        {

        }
    }
}