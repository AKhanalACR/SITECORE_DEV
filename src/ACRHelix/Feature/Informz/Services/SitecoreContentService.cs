using ACRHelix.Feature.Informz.Models;
using ACRHelix.Foundation.Repository.Content;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Informz.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
    }
    public Models.InformzPage GetInformzContent(ID Id)
    {
      return _repository.GetContentItem<Models.InformzPage>(Id);
    }

    public SignupForNews GetSignupContent(string Id)
    {
      return _repository.GetContentItem<SignupForNews>(Id);
    }
  }
}