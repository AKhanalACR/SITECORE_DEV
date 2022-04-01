using ACRHelix.Feature.Callouts.Models;
using ACRHelix.Foundation.Repository.Content;
using System.Collections.Generic;
using Sitecore.Links;

namespace ACRHelix.Feature.Callouts.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
    }
    public ICallouts GetCalloutsContent(string contentGuid)
    {
      return _repository.GetContentItem<ICallouts>(contentGuid);
    }

    public ICalloutsItem GetCalloutItem(string contentGuid)
    {
      return _repository.GetContentItem<ICalloutsItem>(contentGuid);
    }

    public static IEnumerable<ItemData> GetContentItemDataByTemplateID(string templateId)
    {
      var items = new List<ItemData>();

      var db = Sitecore.Context.Database;
      if (db == null)
      {
        db = Sitecore.Configuration.Factory.GetDatabase("master");
      }
      string query = string.Format("fast:/sitecore/content//*[@@templateid='{0}']", templateId);

      var result = db.SelectItems(query);
      foreach (var item in result)
      {
        ItemData idata = new ItemData();
        idata.Id = item.ID;
        idata.NameTitle = item.Fields["Title"] == null ? item.Name : (string.IsNullOrWhiteSpace(item.Fields["Title"].Value) ? item.Name : item.Fields["Title"].Value);
        idata.Url = LinkManager.GetItemUrl(item);
        items.Add(idata);
      }
      return items;
    }

  }
}