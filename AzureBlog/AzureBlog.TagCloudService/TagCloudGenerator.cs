using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AzureBlog.Model.Repository.Concrete;
using AzureBlog.Model;
using AzureBlog.Model.Repository.Abstracts;

namespace AzureBlog.TagCloudService
{
    public class TagCloudGenerator
    {
        ITagRepository _repo;
        public TagCloudGenerator(ITagRepository repository)
        {
            _repo = repository;
        }

        public IEnumerable<TagCloudEntry> GetEntries()
        {
            var tags = from t in _repo.GetAll()
                       group t by t into grp
                       select new
                       {
                           Tag = grp.Key,
                           Count = grp.Count()
                       };

            var maxCount = tags.Max(o => o.Count); // Equals a weight of 1

            foreach (var tag in tags)
            {
                yield return new TagCloudEntry
                {
                    Tag = tag.Tag,
                    Weight = tag.Count / (double)maxCount
                };
            }
        }
    }
}
