using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.RhecContent.Models
{
  public class OurVisionTiles : IOurVisionTiles
  {
    public ID Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public Image Icon { get; set; }
    public string Text { get; set; }
  }
}