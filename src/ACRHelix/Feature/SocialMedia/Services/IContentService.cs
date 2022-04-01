using ACRHelix.Feature.SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SocialMedia.Services
{
    public interface IContentService
    {
        ISocialMedia GetSocialMediaContent(string contentGuid);
        ISocialMediaLinkList GetSocialMediaLinkListContent(string contentGuid);
        ISocialMediaFeed GetSocialMediaFeedContent(string contentGuid);
    }
}