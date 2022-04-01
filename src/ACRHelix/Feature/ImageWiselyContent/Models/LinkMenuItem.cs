using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    public class LinkMenuItem : ILinkMenuItem
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public Link Link { get; set; }
    }
}