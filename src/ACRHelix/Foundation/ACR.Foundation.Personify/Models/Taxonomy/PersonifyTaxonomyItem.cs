using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Configuration;
using ACR.Foundation.Personify.Models.Base;
using Glass.Mapper.Sc.Fields;

namespace ACR.Foundation.Personify.Models.Taxonomy
{
  [SitecoreType(TemplateId = "{063C8E34-BB41-4209-8F3D-C2D1DD2E3745}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class PersonifyTaxonomyItem : IBasePersonifyItem
  {
    public static ID TemplateID = new ID("{063C8E34-BB41-4209-8F3D-C2D1DD2E3745}");


    //public TaxonomyFolder Parent { get; set; }
    public virtual ID ID { get; set; }
    public virtual string Name { get; set; }

    [SitecoreField("Friendly Name")]
    public virtual string FriendlyName { get; set; }

    public virtual Image Icon { get; set; }

    public virtual IBasePersonifyItem Parent { get; set; }

    [SitecoreField("Personify ID")]
    public virtual string PersonifyID { get; set; }

    [SitecoreField("Display Name")]
    public virtual string DisplayName { get; set; }

    [SitecoreField("Omit from Search")]
    public virtual bool OmitFromSearch { get; set; }

    public override bool Equals(object obj)
    {
      var other = obj as PersonifyTaxonomyItem;
      if (other != null)
      {
        return this.ID == other.ID;
      }
      return false;
    }

    public override int GetHashCode()
    {
      return this.ID.GetHashCode();
    }

  }
  /*
  public class PersonifyTaxonomyItemComparer<T> : IEqualityComparer<T> where T : PersonifyTaxonomyItem
  {
    public bool Equals(T x, T y)
    {
      return x.ID == y.ID;
    }

    public int GetHashCode(T obj)
    {
      return obj.ID.GetHashCode();
    }
  }*/
}