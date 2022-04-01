using ACRHelix.Feature.Social.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Social.Services
{
    public interface IContentService
    {
        IFooter GetSocialFooterContent(string contentGuid);
        ISocialList GetSocialListContent(string contentGuid);
    }
}