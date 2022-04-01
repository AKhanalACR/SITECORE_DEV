using ACRHelix.Feature.VORBlogContent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.VORBlogContent.Services
{
  public interface IContentService
  {
    IVORFeaturedBlog GetVORFeaturedXBlogContent(string contentGuid);
    IVORSubscription GetVORSubscriptionLink(string contentGuid);



  }
}