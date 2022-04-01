using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.RhecContent.ViewModels
{
    public class TopicViewModel
  {
    public  ID Id { get; set; }
    public string Name { get; set; }
    public string TopicName { get; set; }

    public string redirectUrl { get; set; }
    public bool isActive { get; set; }
  }
}