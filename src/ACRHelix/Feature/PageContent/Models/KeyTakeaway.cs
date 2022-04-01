using System.Collections.Generic;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
  public class KeyTakeaway : ICMSEntity
  {
    public virtual ID Id { get; set; }
    public virtual string Title { get; set; }
    public virtual string Instructions { get; set; }

    public virtual string Takeaways { get; set; }
    [SitecoreChildren]
    public virtual IEnumerable<TextSection> Children { get; set; }
  }

}