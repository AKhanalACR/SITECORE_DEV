using ACRHelix.Feature.AdditionalResources.Models;
using ACRHelix.Foundation.Dictionary.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.AdditionalResources.Models
{
  public class AdditionalResources : ICMSEntity
  {
    public virtual ID Id { get; set; }
    public virtual string Title { get; set; }
    public virtual string SubTitle { get; set; }
    [SitecoreField("Display Count")]
    public virtual int DisplayCount { get; set; }
    public virtual  IEnumerable<AdditionalResourcesItem> Resources { get; set; }
  }
}