
using System;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.RadPACContent.ViewModels
{
    public class TwitterFeedsViewModel
    {
        public ID Id { get; set; }

        public string TimelineUrl { get; set; }

        public int TweetsDisplay { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
    }
}