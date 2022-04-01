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
  public class Slide : ISlide
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public Image Image { get; set; }
    public Link Link { get; set; }

    public string ImageUrl { get; set; }

    public string LinkUrl { get; set; }
  }
}