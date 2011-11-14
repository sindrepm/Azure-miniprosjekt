using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AzureBlog.Model.Entities;

namespace AzureBlog.Model
{
    public class AzureBlogContext : DbContext
    {
        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public virtual void Commit() {
            base.SaveChanges();
        }
    }
}