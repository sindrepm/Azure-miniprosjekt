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
        readonly ITagRepository _repo;
        public TagCloudGenerator(ITagRepository repository)
        {
            _repo = repository;
        }

        public IEnumerable<TagCloudEntry> GetEntries()
        {
            var tags = from t in _repo.GetAll()
                       group t by t.Name into grp
                       select new
                       {
                           Tag = grp.Key,
                           Count = grp.Count()
                       };

            //yield return new TagCloudEntry { Tag = "C#", Weight = 0.8 };
            //yield return new TagCloudEntry { Tag = "Java", Weight = 0.5 };
            //yield return new TagCloudEntry { Tag = "PHP", Weight = 0.2 };

            if (!tags.Any())
                yield break;

            var maxCount = tags.Max(o => o.Count); // Equals a weight of 1

            foreach (var entry in tags)
            {
                yield return new TagCloudEntry
                {
                    Tag = entry.Tag,
                    Weight = entry.Count / (double)maxCount
                };
            }
        }
    }
}
