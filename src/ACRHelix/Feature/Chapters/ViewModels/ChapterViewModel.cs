
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.Chapters.ViewModels
{
  public class ChapterViewModel
  {
    public ID Id { get; set; }
    public string Title { get; set; }
    [SitecoreField("Chapter Logo")]
    public Image ChapterLogo { get; set; }
    public Link ChapterWebsite { get; set; }
    public Image Image { get; set; }
  }
}