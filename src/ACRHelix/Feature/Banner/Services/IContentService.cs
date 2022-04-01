using ACRHelix.Feature.IdeasBanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.IdeasBanner.Services
{
    public interface IContentService
    {
        Models.IdeasBanner GetIdeasBannerContent(string contentGuid);
    }
}