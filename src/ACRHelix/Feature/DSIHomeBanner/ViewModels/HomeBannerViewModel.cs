using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.DSIHomeBanner.ViewModels
{
  public class HomeBannerViewModel
  {
    public ID Id { get; set; }    
    public string Title { get; set; }    
    public string SubTitle { get; set; }   
    public Link Link { get; set; }   
    public Image BGImage { get; set; }
  }
}