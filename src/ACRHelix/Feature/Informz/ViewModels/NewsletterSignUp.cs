using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.Informz.ViewModels
{
  public class NewsletterSignUp
  {
    public ID Id { get; set; }
    public string Title { get; set; }

    public Link Link { get; set; }
  }
}