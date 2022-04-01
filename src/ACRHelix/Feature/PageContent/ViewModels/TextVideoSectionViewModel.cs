using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.ViewModels
{
  public class TextVideoSectionViewModel
  { 
    public ID Id { get; set; }
    public Link Video { get; set; }
    public string Text { get; set; }
    public string SubTitle { get; set; }
    public string Title { get; set; }
  }
}