using ACRHelix.Feature.TabbedSlider.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.TabbedSlider.Models
{
  public class TabbedSlider : ITabbedSlider
  {
    public ID ID { get; set; }
    public IEnumerable<ITab> Tabs { get; set; }
    public Link Link { get; set; }
  }
}