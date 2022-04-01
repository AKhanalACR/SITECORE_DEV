using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Fields;
using System.Linq;
using System.Web;
using Sitecore.Data;
using ACRHelix.Feature.DsiNewsAndBlogs.Models;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
  public class LatestItemSection : ILatestItemSection
  {
    public ID Id { get; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
  }
}