using ACRHelix.Feature.Advertisements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Advertisements.Services
{
    public interface IContentService
    {
        ITopBannerAd GetAdvertisementsContent(string contentGuid);
        IAdBar GetAdBarContent(string contentGuid);
    }
}