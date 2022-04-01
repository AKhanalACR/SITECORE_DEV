using System.Collections.Generic;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.PageContent.Models
{
  public class Countdown : ICMSEntity
  {
    public virtual ID Id { get; set; }
    public virtual string Title { get; set; }
    public virtual string SubTitle { get; set; }
    public virtual Image Image { get; set; }
    public virtual Link Link { get; set; }
    public virtual System.DateTime TargetDate { get; set; }
    public virtual string DisplayType { get; set; }
  }

}