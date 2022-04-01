using RHEC.Website.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RHEC.Website.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public IRhec GetRhecContent(string contentGuid)
        {
            return _repository.GetContentItem<IRhec>(contentGuid);
        }
    public ILogo GetLogoContent(string contentGuid)
    {
      return _repository.GetContentItem<ILogo>(contentGuid);
    }
    public IButton GetButtonContent(string contentGuid)
    {
      return _repository.GetContentItem<IButton>(contentGuid);
    }
    public ILinkMenu GetLinkMenuContent(string contentGuid)
    {
      return _repository.GetContentItem<ILinkMenu>(contentGuid);
    }
    public ICopyright GetCopyrightContent(string contentGuid)
    {
      return _repository.GetContentItem<ICopyright>(contentGuid);
    }
    public IPartnersLogo GetPartnersLogoContent(string contentGuid)
    {
      return _repository.GetContentItem<IPartnersLogo>(contentGuid);
    }
  }
}