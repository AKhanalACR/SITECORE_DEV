using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
    public interface IDsiPageTitleWithImage : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }

        [SitecoreField("TitleImage")]
        Image TitleImage { get; set; }

        [SitecoreField("Title Background Image")]
        Image TitleBackgroundImage { get; set; }
    }
}