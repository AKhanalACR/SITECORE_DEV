using ACRHelix.Feature.Toolkits.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ACRHelix.Feature.Toolkits.Models
{
    public class PfccMediaItem : IPfccMediaItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Keywords { get; set; }

        public string Extension { get; set; }

        public string MimeType { get; set; }

        public string Icon { get; set; }

        public Stream Blob { get; set; }
    }
}