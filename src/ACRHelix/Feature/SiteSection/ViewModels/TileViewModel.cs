using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.SiteSection.ViewModels
{
  public class TileViewModel
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    [SitecoreField("Short Title")]
    public string ShortTitle { get; set; }
    [SitecoreField("Tile Text")]
    public string TileText { get; set; }
    public Image Image { get; set; }
    public string Url { get; set; }
    [SitecoreField("Link Text")]
    public string LinkText { get; set; }
    [SitecoreField("Link")]
    public Link Link { get; set; }
    //[SitecoreInfo(Glass.Mapper.Sc.Configuration.SitecoreInfoType.TemplateName)]
    public ID TemplateID { get; set; }

    public ID TargetID { get; set; }

    public string NextSessionDate { get; set; }
  }
}