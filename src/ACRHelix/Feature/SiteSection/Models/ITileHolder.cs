using ACRHelix.Feature.SiteSection.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration;
using Sitecore.Data;

namespace ACRHelix.Feature.SiteSection.Models
{
  [SitecoreType(TemplateId = "{9F0A9EEC-5F72-4004-854A-646EB6343EC6}", AutoMap = true, EnforceTemplate = SitecoreEnforceTemplate.Template)]
  public interface ITileHolder : ICMSEntity
  {
    ID Id { get; set; }
    string Title { get; set; }

    //string LinkText { get; set; }
    [SitecoreField("Tiles", FieldType = SitecoreFieldType.Treelist)]
    IEnumerable<ITile> Tiles { get; set; }
    int? TilesPerPage { get; set; }

    [SitecoreField("Display All Children", FieldType = SitecoreFieldType.Checkbox)]
    bool DisplayAllChildren { get; set; }

  }
}