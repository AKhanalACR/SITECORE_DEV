using Glass.Mapper.Sc.Fields;
using System;
using Sitecore.Data;

namespace ACRHelix.Feature.Callouts.ViewModels
{
  public class CalloutsItemViewModel
  {
    public ID Id { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public bool HasTitle => !String.IsNullOrEmpty(Title);
    public string Teaser { get; set; }
    public Image Image { get; set; }
    public Link Link { get; set; }

    public bool ChapterLocator { get; set; } = false;

    public string NoContainCss { get; set; }
    public string ImageLeftRightClass { get; set; }
    public string OppositeImageLeftRightClass { get; set; }
  }
}