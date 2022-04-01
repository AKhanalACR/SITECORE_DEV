
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.Callouts.Models
{
  public class CalloutsItem : ICalloutsItem
  {
    public ID Id { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Teaser { get; set; }
    public Image Image { get; set; }
    public Link Link { get; set; }
  }
}
