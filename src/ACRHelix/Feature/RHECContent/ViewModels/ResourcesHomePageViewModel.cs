using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Feature.RhecContent.Models;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.RhecContent.ViewModels
{
    public class ResourcesHomePageViewModel
  {
    public  ID Id { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public IEnumerable<Resource> Resources { get; set; }
    public string TopicTitle { get; set; }
    public IEnumerable<TopicViewModel> Topics { get; set; }
    
    }
}