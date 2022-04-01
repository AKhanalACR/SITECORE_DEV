using ACRHelix.Feature.TabbedSlider.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.TabbedSlider.Models
{
  public interface ISlide : ICMSEntity
  {
    Guid Id { get; set; }
    string Title { get; set; }
    string Text { get; set; }
    Image Image { get; set; }
    Link Link { get; set; }

    string ImageUrl { get; set; }
    string LinkUrl { get; set; }
  }
}