using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System.Collections.Generic;

namespace ACRHelix.Feature.RhecContent.Models
{
  public class OurVision : IOurVision
  {
    public ID Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public Image Image { get; set; }
    public string LinkText { get; set; }
    public Link Link { get; set; }

    public IEnumerable<IOurVisionTiles> Tiles { get; set; }
  }
}