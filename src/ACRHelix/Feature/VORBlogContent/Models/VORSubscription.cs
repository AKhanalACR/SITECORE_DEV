using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Fields;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.VORBlogContent.Models
{
  public class VORSubscription : IVORSubscription
  {
    public ID Id { get; }
    public Link SubscriptionLink { get; set; }
  }
}