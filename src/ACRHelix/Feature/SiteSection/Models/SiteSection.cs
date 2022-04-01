using ACRHelix.Feature.SiteSection.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SiteSection.Models
{
    public class SiteSection : ISiteSection
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public Image HeaderImage { get; set; }
        public string Heading { get; set; }
    }
}