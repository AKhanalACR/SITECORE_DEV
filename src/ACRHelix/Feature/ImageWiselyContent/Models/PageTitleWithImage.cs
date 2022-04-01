using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{    
    public class PageTitleWithImage : IPageTitleWithImage
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public Image Image { get; set; }
    }
}