
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
    public interface ITeaserWithImageSummary : ICMSEntity
    {
        ID Id { get; }
        string Title { get; }
        Image Image { get; }
        string Summary { get; }
        string NoContainCss { get; }
        string ImageLeftRightClass { get; }
        string OppositeImageLeftRightClass { get; }
        string Url { get; }
    }
}