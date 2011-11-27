using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzureBlog.Model.Service.Abstracts
{
    public interface ITagService
    {
        IList<TagCloudService.TagCloudEntry> GetTagCloud();
    }
}
