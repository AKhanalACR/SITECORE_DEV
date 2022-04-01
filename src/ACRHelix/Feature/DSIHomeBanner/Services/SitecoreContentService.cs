using ACRHelix.Feature.DSIHomeBanner.Models;
using ACRHelix.Foundation.Repository.Content;

namespace ACRHelix.Feature.DSIHomeBanner.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
    }
   
    public Models.DSIHomeBanner GetDSIHomeBannerContent(string contentGuid)
    {
      return _repository.GetContentItem<Models.DSIHomeBanner>(contentGuid);
    }
	
	public IHomeBanner GetHomeBannerContent(string contentGuid)
    {
      return _repository.GetContentItem<IHomeBanner>(contentGuid);
    }

    public IBlockCallout GetBlockCallout(string contentGuid)
    {
      return _repository.GetContentItem<IBlockCallout>(contentGuid);
    }

    public IDSICalloutItem GetCalloutItem(string contentGuid)
    {
      return _repository.GetContentItem<IDSICalloutItem>(contentGuid);
    }
  }
}