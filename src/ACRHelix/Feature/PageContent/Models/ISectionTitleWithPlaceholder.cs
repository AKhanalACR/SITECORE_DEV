using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
    public interface ISectionTitleWithPlaceholder : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }
    }
}