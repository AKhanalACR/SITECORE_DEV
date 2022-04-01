
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.Chapters.Models
{
  public class Chapters : IChapters
  {
    public ID Id { get; set; }
    public string Title { get; set; }
    public Link ChapterWebsite { get; set; }
    public Image ChapterLogo { get; set; }
    //public Image Image { get; set; }
  }
}