using ACRHelix.Feature.Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Login.Services
{
  public interface IContentService
  {
    Models.Login GetLoginContent(string contentGuid);
  }
}