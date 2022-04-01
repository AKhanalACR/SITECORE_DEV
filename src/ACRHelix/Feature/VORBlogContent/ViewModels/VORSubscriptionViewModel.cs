using ACRHelix.Feature.VORBlogContent.Models;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data;

namespace ACRHelix.Feature.VORBlogContent.ViewModels
{
  public class VORSubscriptionViewModel : IVORSubscription
  {
    public ID Id { get; set; }

    public Link SubscriptionLink { get; set; }
  }
}