
using ACRHelix.Project.Decamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.Decamp.Services
{
  public interface IContentService
  {
    ILogo GetLogoContent(string contentGuid);
    IDecampFooter GetCopyrightContent(string contentGuid);
    
    ILinkMenu GetLinkMenuContent(string contentGuid);
    
  }
}