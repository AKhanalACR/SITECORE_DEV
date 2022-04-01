
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
    public class TeaserWithImageSummary : ITeaserWithImageSummary
    {
        public ID Id { get; }
        public string Title { get; }
        public Image Image { get; }
        public string Summary { get; }
        public string NoContainCss { get; set; }
        public string ImageLeftRightClass { get; set; }
        public string OppositeImageLeftRightClass { get; set; }
        public string Url { get; set; }
    }
}