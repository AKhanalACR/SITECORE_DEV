using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Foundation.Repository.Content
{
  public class SitecoreContentRepository : IContentRepository
  {
    private readonly ISitecoreContext _sitecoreContext;

    public SitecoreContentRepository()
    {
      _sitecoreContext = new SitecoreContext();
    }

    public SitecoreContentRepository(string database)
    {
      var db = Sitecore.Configuration.Factory.GetDatabase(database);
      if (db != null)
      {
        _sitecoreContext = new SitecoreContext(db);
      }
    }

    public virtual T GetContentItem<T>(string contentGuid) where T : class, ICMSEntity
    {
      Assert.ArgumentNotNullOrEmpty(contentGuid, "contentGuid");
      return _sitecoreContext.GetItem<T>(Guid.Parse(contentGuid));
    }

    public virtual T GetContentItem<T>(ID Id) where T : class, ICMSEntity
    {
      Assert.ArgumentNotNull(Id, "item ID");
      return _sitecoreContext.GetItem<T>(Id.ToGuid());
    }

  }
}