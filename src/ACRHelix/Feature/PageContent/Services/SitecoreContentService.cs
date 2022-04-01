using ACRHelix.Feature.PageContent.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.PageContent.Services
{
  public class SitecoreContentService : IContentService
  {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
          _repository = repository;
        }
        public ITeaserWithImageSummary GetTeaserWithImageSummaryContent(string contentGuid)
    {
      return _repository.GetContentItem<ITeaserWithImageSummary>(contentGuid);
    }
        /*
        public IHeaderBody GetHeaderBodyContent(string contentGuid)
        {
          return _repository.GetContentItem<IHeaderBody>(contentGuid);
        }
        */
        public TextImageSection GetTextImageContent(string contentGuid)
        {
          return _repository.GetContentItem<TextImageSection>(contentGuid);
        }

        public TextSection GetTextContent(string contentGuid)
        {
          return _repository.GetContentItem<TextSection>(contentGuid);
        }

        public TextSectionCallout GetTextContentCallout(string contentGuid)
        {
          return _repository.GetContentItem<TextSectionCallout>(contentGuid);
        }

        public PageTitleWithImage GetPageTitleWithImageContent(string contentGuid)
        {
          return _repository.GetContentItem<PageTitleWithImage>(contentGuid);
        }

        public PageTitle GetPageTitleContent(string contentGuid)
        {
          return _repository.GetContentItem<PageTitle>(contentGuid);
        }

        public KeyTakeaway GetKeyTakeaway(string contentGuid)
        {
          return _repository.GetContentItem<KeyTakeaway>(contentGuid);
        }

        public ILinkSection GetLinkSectionContent(string contentGuid)
        {
          return _repository.GetContentItem<LinkSection>(contentGuid);
        }

        public IRichTextSection GetRichTextSectionContent(string contentGuid)
        {
          return _repository.GetContentItem<RichTextSection>(contentGuid);
        }
        public IVideoSection GetVideoSectionContent(string contentGuid)
        {
          return _repository.GetContentItem<VideoSection>(contentGuid);
        }
        public ISectionTitleWithPlaceholder GetSectionTitleWithPlaceholderContent(string contentGuid)
        {
          return _repository.GetContentItem<SectionTitleWithPlaceholder>(contentGuid);
        }
        public IFormSection GetFormSectionContent(string contentGuid)
        {
          return _repository.GetContentItem<IFormSection>(contentGuid);
        }
        public IImageHolder GetImageHolderContent(string contentGuid)
        {
          return _repository.GetContentItem<IImageHolder>(contentGuid);
        }
       public IImageHolderWithLink GetImageHolderWithLinkContent(string contentGuid)
        {
          return _repository.GetContentItem<IImageHolderWithLink>(contentGuid);
        }
        public TextVideoSection GetTextVideoSectionContent(string contentGuid)
        {
          return _repository.GetContentItem<TextVideoSection>(contentGuid);
        }

        public BlueLinkList GetBlueLinkedListContent(string contentGuid)
        {
          return _repository.GetContentItem<BlueLinkList>(contentGuid);
        }

        public SideContent GetSideContent(string contentGuid)
        {
          return _repository.GetContentItem<SideContent>(contentGuid);
        }

        public IDismissibleNotification GetDismissibleNotificationContent(string contentGuid)
        {
          return _repository.GetContentItem<DismissibleNotification>(contentGuid);
        }

        public IRliPageTitleSection GetRliPageTitleSectionContent(string contentGuid)
        {
            return _repository.GetContentItem<IRliPageTitleSection>(contentGuid);
        }

        public IWelcomeHub GetWelcomeHubContent(string contentGuid)
        {
            return _repository.GetContentItem<IWelcomeHub>(contentGuid);
        }
        public Countdown GetCountdownContent(string contentGuid)
        {
          return _repository.GetContentItem<Countdown>(contentGuid);
    }
  }
}