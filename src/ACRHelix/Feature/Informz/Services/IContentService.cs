using ACRHelix.Feature.Informz.Models;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Informz.Services
{
  public interface IContentService
  {
    Models.InformzPage GetInformzContent(ID Id);

    SignupForNews GetSignupContent(string Id);
  }
}