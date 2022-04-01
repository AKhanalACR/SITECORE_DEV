using ACRHelix.Feature.Biography.Models;
using ACRHelix.Feature.StaffDirectory.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.StaffDirectory.Models
{
  public class StaffDirectory : ICMSEntity
  {
    public virtual ID Id { get; set; }
    public virtual string Title { get; set; }
    [SitecoreChildren]
    public virtual IEnumerable<IBiography> Biographies { get; set; }
    [SitecoreField(FieldName = "Hide Email Phone", FieldType = Glass.Mapper.Sc.Configuration.SitecoreFieldType.Checkbox)]
    public virtual bool HideEmailPhone { get; set; }

  }
}