using ACRHelix.Feature.DSIHomeBanner.Models;

namespace ACRHelix.Feature.DSIHomeBanner.Services
{
  public interface IContentService
  {
    Models.DSIHomeBanner GetDSIHomeBannerContent(string contentGuid);
    IHomeBanner GetHomeBannerContent(string contentGuid);
    IDSICalloutItem GetCalloutItem(string contentGuid);
    IBlockCallout GetBlockCallout(string contentGuid);
  }
}