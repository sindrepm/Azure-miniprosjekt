using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AzureBlog.Model.Service.Abstracts;
using System.ServiceModel;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace AzureBlog.Model.Service.Concrete
{
    public class TagService : ITagService
    {
        public IList<TagCloudService.TagCloudEntry> GetTagCloud()
        {
            var client = 
                new TagCloudService.TagCloudServiceClient(
                    new NetTcpBinding(SecurityMode.None), 
                    new EndpointAddress(
                        string.Format(
                            "net.tcp://65.52.137.69:1234/TagCloudService")));

            return client.GetTagCloudEntries();
        }
    }
}
