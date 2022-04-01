using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Glass.Mapper.Sc.Configuration;

namespace ACRHelix.Feature.DSIHomeBanner.Models
{
  [SitecoreType(TemplateId = "{ACB522C7-3088-48BF-9C57-4255A8709A28}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public interface IBlockCallout : ICMSEntity
  {
    ID Id { get; set; }

    [SitecoreField("{EF98BA86-CF79-4A98-A98C-0FF8B4BF0635}", SitecoreFieldType.SingleLineText)]
    string Title { get; set; }

    [SitecoreField("{2D621942-F71F-44C0-B6F2-89D8986F1489}", SitecoreFieldType.Image)]
    Image Image { get; set; }

    [SitecoreField("{74537974-5583-4D13-B3B4-D9D95A5B8809}", SitecoreFieldType.GeneralLink)]
    Link Link { get; set; }
  }
}
