using ACRHelix.Feature.Tabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Tabs.Services
{
  public interface IContentService
  {
        Models.Tabs GetTabsContent(string contentGuid);

        RLITabs GetRliTabsContent(string contentGuid);
    }
}