using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Feature.PageContent.Models;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.PageContent.ViewModels
{
  public class CountdownViewModel
  {
    public ID Id { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public Image Image { get; set; }
    public Link Link { get; set; }
    public DateTime TargetDate { get; set; }
    public string DisplayType { get; set; }
  }
}