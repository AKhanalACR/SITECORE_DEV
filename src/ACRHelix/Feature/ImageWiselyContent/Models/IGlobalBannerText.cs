using ACRHelix.Feature.ImageWiselyContent.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    [SitecoreType(AutoMap = true)]
    public interface IGlobalBannerText : ICMSEntity
    {
        ID Id { get; set; }
        string Text { get; set; }
    }
}