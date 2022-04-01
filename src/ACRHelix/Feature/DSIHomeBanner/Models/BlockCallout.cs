
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.DSIHomeBanner.Models
{
  public class BlockCallout : IBlockCallout
  {
    public ID Id { get; set; }
    public string Title { get; set; }
    public Image Image { get; set; }
    public Link Link { get; set; }
  }
}
