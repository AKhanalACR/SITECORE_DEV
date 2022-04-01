using ACRHelix.Feature.ImageWiselyContent.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    public class PageTitleSection : IPageTitleSection
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        [SitecoreField("Sub Title")]
        public string SubTitle { get; set; }
        public string RichText { get; set; }
        public Link Link { get; set; }
        public Image Image { get; set; }
        [SitecoreField("Background Image")]
        public Image BackgroundImage { get; set; }
    }
}