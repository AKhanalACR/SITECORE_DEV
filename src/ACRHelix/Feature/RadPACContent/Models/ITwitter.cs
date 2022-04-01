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
    public interface ITwitter : ICMSEntity
    {
        ID Id { get; set; }

        [SitecoreField("Twitter Timeline Url")]
        string TimelineUrl { get; set; }

        [SitecoreField("Tweets  Display Number")]
        int TweetsDisplay { get; set; }
        int Width { get; set; }
        int Height { get; set; }
       
    }
}