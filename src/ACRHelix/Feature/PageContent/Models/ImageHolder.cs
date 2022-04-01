using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
    public class ImageHolder : IImageHolder
    {
        public ID Id { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}