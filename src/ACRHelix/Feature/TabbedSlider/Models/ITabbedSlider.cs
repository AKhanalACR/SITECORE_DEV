using ACRHelix.Feature.TabbedSlider.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.TabbedSlider.Models
{
  public interface ITabbedSlider : ICMSEntity
  {
    ID ID { get; set; }
    
    IEnumerable<ITab> Tabs { get; }

    Link Link { get; set; }
  }
}