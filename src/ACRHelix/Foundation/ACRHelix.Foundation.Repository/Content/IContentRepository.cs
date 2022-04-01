using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Foundation.Repository.Content
{
  public interface IContentRepository
  {
    T GetContentItem<T>(string contentGuid) where T : class, ICMSEntity;
    T GetContentItem<T>(ID Id) where T : class, ICMSEntity;
  }
}