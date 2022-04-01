using ACRHelix.Feature.ImageWiselyContent.Models;
using ACRHelix.Foundation.Repository.Content;

namespace ACRHelix.Feature.ImageWiselyContent.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
    }
    public IImageWiselyContent GetImageWiselyContentContent(string contentGuid)
    {
      return _repository.GetContentItem<IImageWiselyContent>(contentGuid);
    }

    public IGlobalBannerText GetGlobalBannerContent(string contentGuid)
    {
      return _repository.GetContentItem<IGlobalBannerText>(contentGuid);
    }

    public IPageTitleSection GetPageTitleSectionContent(string contentGuid)
    {
      return _repository.GetContentItem<IPageTitleSection>(contentGuid);
    }

    public ITakeThePledge GetTakeThePledgeContent(string contentGuid)
    {
      return _repository.GetContentItem<ITakeThePledge>(contentGuid);
    }

    public IRichTextWithImage GetRichTextWithImageContent(string contentGuid)
    {
      return _repository.GetContentItem<IRichTextWithImage>(contentGuid);
    }

    public IArchive GetArchivesContent(string contentGuid)
    {
      return _repository.GetContentItem<IArchive>(contentGuid);
    }

    public INewsList GetNewsListContent(string contentGuid)
    {
      return _repository.GetContentItem<INewsList>(contentGuid);
    }

    public IRichTextSection GetRichTextSectionContent(string contentGuid)
    {
      return _repository.GetContentItem<IRichTextSection>(contentGuid);
    }

    public IPageTitle GetPageTitleContent(string contentGuid)
    {
      return _repository.GetContentItem<IPageTitle>(contentGuid);
    }

    public IPageTitleWithImage GetPageTitleWithImageContent(string contentGuid)
    {
      return _repository.GetContentItem<IPageTitleWithImage>(contentGuid);
    }

    public IPledgeForm GetPledgeContent(string contentGuid)
    {
      return _repository.GetContentItem<IPledgeForm>(contentGuid);
    }

    public IPledgeTypeFolder GetPledgeTypesList(string contentGuid)
    {
      return _repository.GetContentItem<IPledgeTypeFolder>(contentGuid);
    }

    public IPledgeCounterSection GetPledgeCounterSectionContent(string contentGuid)
    {
      return _repository.GetContentItem<IPledgeCounterSection>(contentGuid);
    }

    public IHonorRoll GetHonorRollContent(string contentGuid)
    {
      return _repository.GetContentItem<IHonorRoll>(contentGuid);
    }

    public ContentSlider GetSlidesContent(string contentGuid)
    {
      return _repository.GetContentItem<ContentSlider>(contentGuid);
    }

    public AdditionalResources GetAdditionalResources(string contentGuid)
    {
        return _repository.GetContentItem<AdditionalResources>(contentGuid);
    }

        public BlockWithTextCallout GetBlockWithTextCalloutContent(string contentGuid)
        {
            return _repository.GetContentItem<BlockWithTextCallout>(contentGuid);
        }
        public InternationFacilityListSettingsModel GetInternationFacilityListSettings(string contentGuid)
    {
      return _repository.GetContentItem<InternationFacilityListSettingsModel>(contentGuid);
    }
    public IArchive2 GetArchivesContent2(string contentGuid)
    {
      return _repository.GetContentItem<IArchive2>(contentGuid);
    }

  }
}