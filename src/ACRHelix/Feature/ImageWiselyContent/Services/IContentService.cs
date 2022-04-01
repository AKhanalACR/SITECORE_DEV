using ACRHelix.Feature.ImageWiselyContent.Models;

namespace ACRHelix.Feature.ImageWiselyContent.Services
{
  public interface IContentService
  {
    IImageWiselyContent GetImageWiselyContentContent(string contentGuid);
    IGlobalBannerText GetGlobalBannerContent(string contentGuid);

    IPageTitleSection GetPageTitleSectionContent(string contentGuid);

    ITakeThePledge GetTakeThePledgeContent(string contentGuid);

    IRichTextWithImage GetRichTextWithImageContent(string contentGuid);

    IArchive GetArchivesContent(string contentGuid);

    INewsList GetNewsListContent(string contentGuid);

    IRichTextSection GetRichTextSectionContent(string contentGuid);

    IPageTitle GetPageTitleContent(string contentGuid);

    IPageTitleWithImage GetPageTitleWithImageContent(string contentGuid);

    IPledgeForm GetPledgeContent(string contentGuid);

    IPledgeTypeFolder GetPledgeTypesList(string contentGuid);

    IPledgeCounterSection GetPledgeCounterSectionContent(string contentGuid);

    IHonorRoll GetHonorRollContent(string contentGuid);

    ContentSlider GetSlidesContent(string contentGuid);

    AdditionalResources GetAdditionalResources(string contentGuid);

    BlockWithTextCallout GetBlockWithTextCalloutContent(string contentGuid);
    InternationFacilityListSettingsModel GetInternationFacilityListSettings(string contentGuid);
    IArchive2 GetArchivesContent2(string contentGuid);
  }
}