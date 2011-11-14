using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AzureBlog.Model
{
    public class AzureBlogDbInitializer : DropCreateDatabaseIfModelChanges<AzureBlogContext>
    {
        protected override void Seed(AzureBlogContext context)
        {
            
        }
    }
}