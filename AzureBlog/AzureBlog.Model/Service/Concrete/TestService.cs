using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AzureBlog.Model.Infrastructure;
using AzureBlog.Model.Repository.Abstracts;
using AzureBlog.Model.Entities;

namespace AzureBlog.Model.Service.Concrete
{
    public class TestService
    {
        private readonly IBlogRepository repository;

        public TestService(IBlogRepository repository)
        {
            this.repository = repository;
        }

        ICollection<BlogPost> GetPostsByTimeSpan(DateTime start, DateTime end)
        {
            return repository.GetMany(p => p.UserId == new Guid()).ToList();
        }
    }
}