using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.RhecContent.Models
{
    public interface ITopics : ICMSEntity
    {
    ID Id { get; set; }
    string Name { get; set; }

    [SitecoreField("{CBE134A3-6993-4FD9-9B5A-14668983FAB1}",Glass.Mapper.Sc.Configuration.SitecoreFieldType.SingleLineText)]
    
    string TopicName { get; set; }

  }
}