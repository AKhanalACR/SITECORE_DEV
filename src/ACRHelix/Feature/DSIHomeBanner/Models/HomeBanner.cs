using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.DSIHomeBanner.Models
{
  
  public class HomeBanner : IHomeBanner
  {
    public ID Id { get; set; }    
    public string Title { get; set; }    
    public string SubTitle { get; set; }
    public Link Link { get; set; }
    public Image BGImage { get; set; }
  }
}