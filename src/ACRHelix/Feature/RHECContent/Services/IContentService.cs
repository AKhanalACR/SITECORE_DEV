using ACRHelix.Feature.RhecContent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.RhecContent.Services
{
    public interface IContentService
    {
    Models.Setting GetSettingItem(string contentGuid);
    IOurVision GetOurVisionContent(string contentGuid);    
    Models.RichTextButton GetRichTextButtonContent(string contentGuid);
    Models.ResourcesHomePage GetResourcesHomePageContent(string contentGuid);
    Models.PageContent GetPageContentContent(string contentGuid);
    Models.Resource GetResourceDetailContent(string contentGuid);
    Models.IListingTopics GetListingTopics(string contentGuid, List<string> listTopics);
    Models.Pledge GetPledgePageContent(string contentGuid);
    Models.PledgeCounter GetPledgeCounterContent(string contentGuid);
    Models.BoxCallout GetBoxCalloutContent(string contentGuid);
  }
}