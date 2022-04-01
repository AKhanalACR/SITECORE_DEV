using ACRHelix.Feature.PageContent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.PageContent.Services
{
  public interface IContentService
  {
        ITeaserWithImageSummary GetTeaserWithImageSummaryContent(string contentGuid);
        //IHeaderBody GetHeaderBodyContent(string contentGuid);
        TextImageSection GetTextImageContent(string contentGuid);
        TextSection GetTextContent(string contentGuid);
        TextSectionCallout GetTextContentCallout(string contentGuid);
        PageTitleWithImage GetPageTitleWithImageContent(string contentGuid);
        PageTitle GetPageTitleContent(string contentGuid);
        ILinkSection GetLinkSectionContent(string contentGuid);
        KeyTakeaway GetKeyTakeaway(string contentGuid);
        IRichTextSection GetRichTextSectionContent(string contentGuid);
        IVideoSection GetVideoSectionContent(string contentGuid);
        ISectionTitleWithPlaceholder GetSectionTitleWithPlaceholderContent(string contentGuid);
        IFormSection GetFormSectionContent(string contentGuid);
        IImageHolder GetImageHolderContent(string contentGuid);
        IImageHolderWithLink GetImageHolderWithLinkContent(string contentGuid);
        TextVideoSection GetTextVideoSectionContent(string contentGuid);
        BlueLinkList GetBlueLinkedListContent(string contentGuid);
        SideContent GetSideContent(string contentGuid);
        IDismissibleNotification GetDismissibleNotificationContent(string contentGuid);

        IRliPageTitleSection GetRliPageTitleSectionContent(string contentGuid);

        IWelcomeHub GetWelcomeHubContent(string contentGuid);
        Countdown GetCountdownContent(string contentGuid);
    }
}