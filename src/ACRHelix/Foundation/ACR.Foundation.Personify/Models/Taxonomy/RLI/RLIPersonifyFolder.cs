using ACR.Foundation.Personify.Models.Base;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Personify.Models.Taxonomy.RLI
{
  [SitecoreType(TemplateId = "{3EBC3DC1-7B83-4B11-B4F1-06930599AE13}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class RLIPersonifyFolder : IBasePersonifyItem
  {
    public virtual ID ID { get; set; }
    public virtual string Name { get; set; }
    public virtual IBasePersonifyItem Parent { get; set; }

    [SitecoreChildren()]
    public virtual IEnumerable<RLIPersonifyCode> RLICodes { get; set; }

  }
}