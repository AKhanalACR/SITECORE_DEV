using ACRHelix.Feature.ImageWiselyContent.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    public class GlobalBannerText : IGlobalBannerText
    {
        public ID Id { get; set; }
        public string Text { get; set; }
    }
}