using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.RadPACContent.Models
{
    public class HomeBanner : IHomeBanner
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string YouTubeEmbedLink { get; set; }
        public string ContributorsList { get; set; }
        public Link Link { get; set; }
        public Image Image { get; set; }
        public Image BannerBackground { get; set; }
    }
}