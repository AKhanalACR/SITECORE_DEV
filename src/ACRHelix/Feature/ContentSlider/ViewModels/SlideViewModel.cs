using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.ContentSlider.ViewModels
{
  public class SlideViewModel
  {
    public ID Id { get; set; }
    public string AlertText { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public Link Link { get; set; }
    public Image Image { get; set; }
  }
}