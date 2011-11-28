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
        public AzureBlogContext()
            : base("DefaultConnection1")
        {
        }

        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public virtual void Commit() {
            base.SaveChanges();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Tag>().Property(i => i.Id).StoreGeneratedPattern
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}