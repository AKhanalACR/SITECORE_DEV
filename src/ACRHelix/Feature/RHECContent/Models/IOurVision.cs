using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.RhecContent.Models
{
    public interface IOurVision : ICMSEntity
    {
     ID Id { get; set; }
    string Name { get; set; }
    string Title { get; set; }
    string SubTitle { get; set; }
    Image Image { get; set; }
    string LinkText { get; set; }
    Link Link { get; set; }

    [SitecoreChildren]
        IEnumerable<IOurVisionTiles> Tiles { get; set; }
  }
}