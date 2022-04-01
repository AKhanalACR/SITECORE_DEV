using ACRHelix.Feature.ACRDashboard.Models;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ACRDashboard.Services
{
  public interface IContentService
  {
    Models.ACRDashboard GetACRDashboardContent(ID dashboardId);
    IEnumerable<DefaultQuickLink> GetSitecoreQuickLinks();
    IEnumerable<DefaultQuickLink> GetDefaultQuickLinks();

  }
}
