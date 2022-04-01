using RHEC.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RHEC.Website.Services
{
    public interface IContentService
    {
        IRhec GetRhecContent(string contentGuid);
       ILogo GetLogoContent(string contentGuid);
    IButton GetButtonContent(string contentGuid);
    ILinkMenu GetLinkMenuContent(string contentGuid);
    ICopyright GetCopyrightContent(string contentGuid);
    IPartnersLogo GetPartnersLogoContent(string contentGuid);
  }
}