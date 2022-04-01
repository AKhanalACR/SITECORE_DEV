using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.SiteSection.Models
{
  [SitecoreType(TemplateId = "{8A90A5C2-CE1F-4117-82B1-392B42CABD8E}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.TemplateAndBase)]
  public interface ITile : ICMSEntity
  {
    Guid Id { get; set; }
    string Title { get; set; }
    [SitecoreField("Tile Text")]
    string TileText { get; set; }
    Image Image { get; set; }
    string Url { get; set; }
    [SitecoreField("Link Text")]
    string LinkText { get; set; }
    [SitecoreField("Link")]
    Link Link { get; set; }
    [SitecoreInfo(Glass.Mapper.Sc.Configuration.SitecoreInfoType.TemplateId)]
    ID TemplateID { get; set; }

    [SitecoreField(FieldName = "Short Title")]
    string ShortTitle { get; set; }
  }
}
