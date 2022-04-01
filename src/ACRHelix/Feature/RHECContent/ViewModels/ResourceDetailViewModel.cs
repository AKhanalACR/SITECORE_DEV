using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Feature.RhecContent.Models;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.RhecContent.ViewModels
{
    public class ResourceDetailViewModel
  {
    public  ID Id { get; set; }

    public  string Title { get; set; }
   
    public  string Body { get; set; }
   
    public  string Summary { get; set; }
  
    public  Image image { get; set; }
   
    public  DateTime PublishDate { get; set; }
   
    public  IEnumerable<TopicViewModel> Topics { get; set; }
    
    public  string LinkOverride { get; set; }

   
    public  bool NewWindow { get; set; }
    public  string Url { get; set; }
  }
}