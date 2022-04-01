using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.Tabs.Models
{    
    public class TabItem
    {
        public string TabName { get; set; }
        public string TabURL { get; set; }
    }
}