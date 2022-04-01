using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.Navigation.Models
{
    public interface IBreadcrumbs : ICMSEntity
    {
        ID Id { get; set; }
        List<Link> Links { get; set; } 
    }
}