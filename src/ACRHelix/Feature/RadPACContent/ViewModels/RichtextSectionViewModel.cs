
using System;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.RadPACContent.ViewModels
{
    public class RichtextSectionViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string RichText { get; set; }
        public string YouTubeEmbedUrl { get; set; }

        public Image Image { get; set; }

        public bool DefaultImageLocation { get; set; }
    }
}