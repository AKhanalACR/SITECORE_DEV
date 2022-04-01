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
    public class Twitter : ITwitter
    {
        public ID Id { get; set; }

        [SitecoreField("Twitter Timeline Url")]
        public string TimelineUrl { get; set; }

        [SitecoreField("Tweets  Display Number")]
        public int TweetsDisplay { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
    }
}