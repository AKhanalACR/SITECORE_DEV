using System;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.DSIHomeBanner.ViewModels
{
  public class BlockCalloutViewModel
  {
    public ID Id { get; set; }
    public string Title { get; set; }
    public Image Image { get; set; }
    public Link Link { get; set; }
  }
}
