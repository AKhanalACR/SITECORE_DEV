using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Social.ViewModels
{
  public class FooterViewModel
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Image Image { get; set; }
    public Link EngageLink { get; set; }
  }
}