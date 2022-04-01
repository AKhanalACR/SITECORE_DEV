using Glass.Mapper.Sc.Fields;
using System;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.ViewModels
{
    public class TeaserWithImageSummaryViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string NoContainCss { get; set; }
        public string ImageLeftRightClass { get; set; }
        public string OppositeImageLeftRightClass { get; set; }
        public Image Image { get; set; }
        public string Summary { get; set; }
        public string Url { get; set; }
    }
}