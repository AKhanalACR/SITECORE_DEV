using ACRHelix.Feature.ImageWiselyContent.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    public interface IPageTitleSection : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }

        [SitecoreField("Sub Title")]
        string SubTitle { get; set; }

        [SitecoreField("Rich Text")]
        string RichText { get; set; }

        Link Link { get; set; }

        Image Image { get; set; }

        [SitecoreField("Background Image")]
        Image BackgroundImage { get; set; }
    }
}