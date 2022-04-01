using ACRHelix.Foundation.Repository.Content;
using ACRHelix.Project.RadPAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.RadPAC.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public ILogo GetLogoContent(string contentGuid)
        {
            return _repository.GetContentItem<ILogo>(contentGuid);
        }

        public ICopyrightText GetCopyrightContent(string contentGuid)
        {
            return _repository.GetContentItem<ICopyrightText>(contentGuid);
        }

        public ISignup GetSignupContent(string contentGuid)
        {
            return _repository.GetContentItem<ISignup>(contentGuid);
        }

        public ILinkMenu GetLinkMenuContent(string contentGuid)
        {
            return _repository.GetContentItem<ILinkMenu>(contentGuid);
        }
        public Login GetLoginContent(string contentGuid)
        {
            return _repository.GetContentItem<Login>(contentGuid);
        }
    }
}