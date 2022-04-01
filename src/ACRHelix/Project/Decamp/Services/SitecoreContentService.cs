using ACRHelix.Foundation.Repository.Content;
using ACRHelix.Project.Decamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.Decamp.Services
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

    public IDecampFooter GetCopyrightContent(string contentGuid)
    {
      return _repository.GetContentItem<IDecampFooter>(contentGuid);
    }

    public ILinkMenu GetLinkMenuContent(string contentGuid)
    {
      return _repository.GetContentItem<ILinkMenu>(contentGuid);
    }
    
  }
}