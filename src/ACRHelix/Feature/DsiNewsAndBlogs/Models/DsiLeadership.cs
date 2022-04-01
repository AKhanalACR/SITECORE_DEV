using ACRHelix.Feature.Biography.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
  public class DsiLeadership : IDsiLeadership
    {
    public ID Id { get; set; }
    public string Title { get; set; }

    public IEnumerable<IBiography> Biographies { get; set; }

    public bool HideEmailPhone { get; set; }

  }
}