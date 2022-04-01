using Glass.Mapper.Sc.Configuration.Attributes;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using Glass.Mapper.Sc.Configuration;

namespace ACRHelix.Feature.PageContent.Models
{
    [SitecoreType(EnforceTemplate = SitecoreEnforceTemplate.Template, TemplateId = "{4BE549F8-5A6A-4777-B32B-9937712D20D3}", AutoMap = true)]
    public interface IRliPageTitleSection : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }

        [SitecoreField("Sub Title")]
        string SubTitle { get; set; }

        [SitecoreField("Banner Background Image")]
        Image BannerBackgroundImage { get; set; }       

        [SitecoreField("RLI Logo")]
        Image RliLogo { get; set; }

        [SitecoreField("Right Callout Text")]
        string RightCalloutText { get; set; }

        [SitecoreField("Right Callout Link")]
        Link RightCalloutLink { get; set; }

        [SitecoreField("Right Callout Image")]
        Image RightCalloutImage { get; set; }
    }
}