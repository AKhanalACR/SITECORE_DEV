using ACRHelix.Feature.Identity.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Identity.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public IIdentity GetIdentityContent(string contentGuid)
        {
            return _repository.GetContentItem<IIdentity>(contentGuid);
        }

        public IContactsFooter GetContactsFooterContent(string contentGuid)
        {
            return _repository.GetContentItem<IContactsFooter>(contentGuid);
        }
        public ILocationsFooter GetLocationsFooterContent(string contentGuid)
        {
            return _repository.GetContentItem<ILocationsFooter>(contentGuid);
        }

        public ICopyrightFooter GetCopyrightFooterContent(string contentGuid)
        {
            return _repository.GetContentItem<ICopyrightFooter>(contentGuid);
        }

        public ILogo GetLogoContent(string contentGuid)
        {
            return _repository.GetContentItem<ILogo>(contentGuid);
        }

        public IIWFooterTopSection GetIWFooterSectionContent(string contentGuid)
        {
            return _repository.GetContentItem<IIWFooterTopSection>(contentGuid);
        }

        public IIdeasNewsContacts GetIdeasNewsContacts(string contentGuid)
        {
            return _repository.GetContentItem<IIdeasNewsContacts>(contentGuid);
        }
    }
}