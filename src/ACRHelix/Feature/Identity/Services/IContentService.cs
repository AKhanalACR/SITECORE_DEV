using ACRHelix.Feature.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Identity.Services
{
    public interface IContentService
    {
        IIdentity GetIdentityContent(string contentGuid);
        IContactsFooter GetContactsFooterContent(string contentGuid);
        ILocationsFooter GetLocationsFooterContent(string contentGuid);
        ICopyrightFooter GetCopyrightFooterContent(string contentGuid);
        ILogo GetLogoContent(string contentGuid);

        IIWFooterTopSection GetIWFooterSectionContent(string contentGuid);
        IIdeasNewsContacts GetIdeasNewsContacts(string contentGuid);
        
    }
}