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
  [SitecoreType(TemplateId = TemplateID, AutoMap = true, EnforceTemplate = SitecoreEnforceTemplate.Template)]
  public class RLIPersonifySubCode : IBasePersonifyItem
  {
    public const string TemplateID = "{8ECACC2E-D05D-4059-8B23-F2CE9ECCBDA6}";
    public virtual ID ID { get; set; }
    public virtual string Name { get; set; }
    public virtual IBasePersonifyItem Parent { get; set; }
    public virtual string SubCode { get; set; }

    public virtual string Code { get; set; }

    public virtual string Description { get; set; }

    public virtual string Option1 { get; set; }

    public virtual string Option2 { get; set; }

    public virtual bool Active { get; set; }

    public virtual bool AvailableToWeb { get; set; }

    public virtual int DisplayOrder { get; set; }

    public virtual DateTime Updated { get; set; }

    public override bool Equals(object obj)
    {
      var other = obj as RLIPersonifySubCode;
      if (other != null)
      {
        return this.ID == other.ID;
      }
      return false;
    }

    public override int GetHashCode()
    {
      return ID.GetHashCode();
    }

  }
}