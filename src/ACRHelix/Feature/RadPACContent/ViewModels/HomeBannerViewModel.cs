
using System;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using System.Collections.Generic;

namespace ACRHelix.Feature.RadPACContent.ViewModels
{
    public class HomeBannerViewModel
    {
        private Models.IHomeBanner _homeBanner = new Models.HomeBanner();
        
        public Models.IHomeBanner HomeBanner
        {
            get { return _homeBanner; }
            set { _homeBanner = value; }
        }

        public string EmbedLink
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(HomeBanner.YouTubeEmbedLink))
                    return HomeBanner.YouTubeEmbedLink.ToLower().StartsWith("https://") || HomeBanner.YouTubeEmbedLink.ToLower().StartsWith("http://") ? HomeBanner.YouTubeEmbedLink : "https://" + HomeBanner.YouTubeEmbedLink;
                else
                    return "";

            }
        }

        public IEnumerable<string> Contributors
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(HomeBanner.ContributorsList))
                    return HomeBanner.ContributorsList.Split(new[] { "\r\n", "\r" }, StringSplitOptions.None);
                else
                    return new string[] { };
            }
        }
    }
}