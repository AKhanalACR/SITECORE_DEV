using ACRHelix.Feature.ACRDashboard.Models;
using ACRHelix.Foundation.Repository.Content;
using Glass.Mapper.Sc;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ACRDashboard.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    //private 
    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
      //_service = new SitecoreService(Sitecore.Context.Database);
    }

    public Models.ACRDashboard GetACRDashboardContent(ID dashboardId)
    {
      return _repository.GetContentItem<Models.ACRDashboard>(dashboardId);
    }

    public IEnumerable<DefaultQuickLink> GetSitecoreQuickLinks()
    {
      List<DefaultQuickLink> quickLinks = new List<DefaultQuickLink>();
      var rootItem = Sitecore.Context.Database.GetItem(Constants.DefaultDashboardQuickLinks.RootFolderID);
      if (rootItem != null)
      {
        SitecoreService _service = new SitecoreService(Sitecore.Context.Database);
        var links = rootItem.GetChildren().Where(x => x.TemplateID == ID.Parse(DefaultQuickLink.TemplateId));
        foreach (var link in links)
        {
          quickLinks.Add(_service.Cast<DefaultQuickLink>(link));
        }
      }
      return quickLinks;
    }

    public IEnumerable<DefaultQuickLink> GetDefaultQuickLinks() {
      return GetSitecoreQuickLinks().Where(x => x.Selected == true);
    }
  }
}