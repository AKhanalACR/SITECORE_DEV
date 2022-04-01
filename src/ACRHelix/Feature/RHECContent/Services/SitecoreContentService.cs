using ACRHelix.Feature.RhecContent.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ACRHelix.Feature.RhecContent.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
    
      public Models.Setting GetSettingItem(string contentGuid)
    {
      return _repository.GetContentItem<Models.Setting>(contentGuid);
    }
    public IOurVision GetOurVisionContent(string contentGuid)
    {
      return _repository.GetContentItem<IOurVision>(contentGuid);
    }
    //public IHomeTopic GetHomeTopicsContent(string contentGuid)
    //{
    //  return _repository.GetContentItem<IHomeTopic>(contentGuid);
    //}
    public Models.RichTextButton GetRichTextButtonContent(string contentGuid)
    {
      return _repository.GetContentItem<Models.RichTextButton>(contentGuid);
    }
    public Models.ResourcesHomePage GetResourcesHomePageContent(string contentGuid)
    {
      return _repository.GetContentItem<Models.ResourcesHomePage>(contentGuid);
    }

    public PageContent GetPageContentContent(string contentGuid)
    {
      return _repository.GetContentItem<Models.PageContent>(contentGuid);
    }
    public Resource GetResourceDetailContent(string contentGuid)
    {
      return _repository.GetContentItem<Models.Resource>(contentGuid);
    }
    public Models.IListingTopics GetListingTopics(string contentGuid, List<string> listTopics)
    {
      var topics= _repository.GetContentItem<Models.IListingTopics>(contentGuid);
      //return _repository.GetContentItem<Models.IListingTopics>(contentGuid);
      if (listTopics.Count>0)
      {
        topics.Topics = topics.Topics.Where(x => listTopics.Contains(x.Name));        
      }
      return topics;
    }
    public Models.Pledge GetPledgePageContent(string contentGuid)
    {
      return _repository.GetContentItem<Models.Pledge>(contentGuid);
    }
    public Models.PledgeCounter GetPledgeCounterContent(string contentGuid)
    {
      return _repository.GetContentItem<Models.PledgeCounter>(contentGuid);
    }
    public Models.BoxCallout GetBoxCalloutContent(string contentGuid)
    {
      return _repository.GetContentItem<Models.BoxCallout>(contentGuid);
    }
    
  }
}