using System;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.DSIHomeBanner.ViewModels
{
  public class DSICalloutItemViewModel
  {
    public ID Id { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public bool HasTitle => !String.IsNullOrEmpty(Title);
    public string Teaser { get; set; }
    public Image Image { get; set; }
    public Link Link { get; set; }
    public Link SecondLink { get; set; }
    public bool AnimateFromRight { get; set; }
  }
}
