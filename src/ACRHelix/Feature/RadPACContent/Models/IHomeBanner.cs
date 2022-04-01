using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.RadPACContent.Models
{
    public interface IHomeBanner : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }
        string YouTubeEmbedLink { get; set; }
        string ContributorsList { get; set; }
        Link  Link { get; set; }

        Image Image { get; set; }

        [SitecoreField("BannerBackgroundImage")]
        Image BannerBackground { get; set; }
    }
}