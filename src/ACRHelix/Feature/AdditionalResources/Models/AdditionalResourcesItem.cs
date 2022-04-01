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
	public class AdditionalResourcesItem : ICMSEntity
	{
		public virtual ID Id { get; set; }
		public virtual string Title { get; set; }
		public virtual string TemplateName { get; set; }
		public virtual string Url { get; set; }

    public string GetUrl()
    {
      if (TemplateName == "External Navigation Item")
      {
        var item = Sitecore.Context.Database.GetItem(Id);
        if (item != null)
        {
          return item.Fields["Link Override"].Value;
        }
      }
      return Url;
    }

		public override bool Equals(object other) //note parameter is of type object
		{
			AdditionalResourcesItem t = other as AdditionalResourcesItem;
			return (t != null) ? Id.Equals(t.Id) : false;
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
}