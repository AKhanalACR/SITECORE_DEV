
using ACRHelix.Project.RadPAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.RadPAC.Services
{
    public interface IContentService
    {
        ILogo GetLogoContent(string contentGuid);
        ICopyrightText GetCopyrightContent(string contentGuid);
        ISignup GetSignupContent(string contentGuid);
        ILinkMenu GetLinkMenuContent(string contentGuid);
        Login GetLoginContent(string contentGuid);
    }
}