using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{  
    public interface IPledgeTypeFolder : ICMSEntity
    {
        ID Id { get; set; }

        string Name { get; set; }

        [SitecoreChildren]
        IEnumerable<IPledgeType> PledgeTypesList { get; set; }

    }
}