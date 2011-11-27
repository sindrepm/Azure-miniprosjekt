using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AzureBlog.Model.Service.Abstracts;
using System.ServiceModel;

namespace AzureBlog.Model.Service.Concrete
{
    public class TagService : ITagService
    {
        public IList<TagCloudService.TagCloudEntry> GetTagCloud()
        {
            var client = new TagCloudService.TagCloudServiceClient(new NetTcpBinding(SecurityMode.None), new EndpointAddress("net.tcp://127.255.0.1:1234/TagCloudService"));
            return client.GetTagCloudEntries();
        }
    }
}
