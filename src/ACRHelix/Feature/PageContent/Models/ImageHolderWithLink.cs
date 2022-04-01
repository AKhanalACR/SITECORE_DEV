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
    public class ImageHolderWithLink : IImageHolderWithLink
  {
        public ID Id { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public string RedirectUrl { get; set; }

    }
}