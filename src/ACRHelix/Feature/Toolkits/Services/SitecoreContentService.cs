using ACRHelix.Feature.Toolkits.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Toolkits.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public IPfccToolkit GetPfccToolkitContent(string contentGuid)
        {
            return _repository.GetContentItem<IPfccToolkit>(contentGuid);
        }

        public IPfccToolkit GetPfccToolkitFormContent(string contentGuid)
        {
          return _repository.GetContentItem<IPfccToolkit>(contentGuid);
        }

        public IPfccToolkit GetMesoToolkitContent(string contentGuid)
        {
          return _repository.GetContentItem<IPfccToolkit>(contentGuid);
        }

        public ISignupWithEmail GetSignupWithEmailContent(string contentGuid)
        {
          return _repository.GetContentItem<ISignupWithEmail>(contentGuid);
        }

        public IMediaItemList GetMesoFilesContent(string contentGuid)
        {
          return _repository.GetContentItem<IMediaItemList>(contentGuid);
        }
        public string CreateMediaItem(IPfccMediaItem mediaItem)
        {
          //mediaItem.Name = ItemUtil.ProposeValidItemName(mediaItem.Name);
          return ClientService.CreateMediaItem(mediaItem);
        }
        public string CreateMesoMediaItem(IPfccMediaItem mediaItem)
        {
           return ClientService.CreateMediaItem(mediaItem, false);
        }

  }
}