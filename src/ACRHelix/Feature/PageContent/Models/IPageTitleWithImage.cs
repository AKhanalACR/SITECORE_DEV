using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
    public interface IPageTitleWithImage : ICMSEntity
    {
        ID Id { get; set; }
        Image TitleImage { get; set; }
    }
}