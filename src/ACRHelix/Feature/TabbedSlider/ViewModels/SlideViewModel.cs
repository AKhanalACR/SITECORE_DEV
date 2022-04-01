using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.TabbedSlider.ViewModels
{
  public class SlideViewModel
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public Image Image { get; set; }
    public Link Link { get; set; }

    public string ImageUrl { get; set; }

    public string LinkUrl { get; set; }

    public bool PopularTab { get; set; } = false;
  }
}