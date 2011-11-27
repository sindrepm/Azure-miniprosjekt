using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace AzureBlog.TagCloudService
{
    [ServiceContract]
    public interface ITagCloudService
    {
        /// <summary>
        /// Returns a list of entries in the tag cloud.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<TagCloudEntry> GetTagCloudEntries();
    }
}