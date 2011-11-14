using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using AzureBlog.Model.Repository.Concrete;
using AzureBlog.Model;

namespace AzureBlog.TagCloudService
{
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Multiple,
#if DEBUG
 IncludeExceptionDetailInFaults = true,
#else
         IncludeExceptionDetailInFaults = false,
#endif
 AddressFilterMode = AddressFilterMode.Any)]
    class TagCloudService : ITagCloudService
    {
        public IEnumerable<TagCloudEntry> GetTagCloudEntries()
        {
            var context = new AzureBlogContext();
            var tagCloudGenerator = new TagCloudGenerator(new TagRepository(context));

            return tagCloudGenerator.GetEntries();
        }

    }
}
