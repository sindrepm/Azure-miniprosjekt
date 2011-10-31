using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AzureBlog.Models
{
    public class AzureBlogContext : DbContext
    {
        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}