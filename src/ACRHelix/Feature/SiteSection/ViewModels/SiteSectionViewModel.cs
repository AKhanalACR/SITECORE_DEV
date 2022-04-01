using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SiteSection.ViewModels
{
    public class SiteSectionViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        [SitecoreField("Header Image")]
        public Image HeaderImage { get; set; }
        public string Heading { get; set; }
    }
}