using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AzureBlog.TagCloudService
{
    [DataContract]
    public class TagCloudEntry
    {
        [DataMember]
        public string Tag { get; set; }
        /// <summary>
        /// Between 0-1.
        /// </summary>
        [DataMember]
        public double Weight { get; set; }
    }
}
