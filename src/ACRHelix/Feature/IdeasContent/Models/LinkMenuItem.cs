using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.IdeasContent.Models
{
    public class LinkMenuItem : ILinkMenuItem
    {
        public virtual ID Id { get; set; }
        public virtual string Title { get; set; }
        public virtual Link Link { get; set; }
        public virtual string IconCSSClass { get; set; }
    }
}