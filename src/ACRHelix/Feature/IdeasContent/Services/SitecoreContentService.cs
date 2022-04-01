using ACRHelix.Feature.IdeasContent.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.IdeasContent.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public IIdeasPageContent GetIdeasPageContentContent(string contentGuid)
        {
            return _repository.GetContentItem<IIdeasPageContent>(contentGuid);
        }

        public IIdeasRichText GetIdeasRichTextContent(string contentGuid)
        {
            return _repository.GetContentItem<IIdeasRichText>(contentGuid);
        }

        public IIdeasMapDetails GetMapDetailsContent(string contentGuid)
        {
            return _repository.GetContentItem<IIdeasMapDetails>(contentGuid);
        }

        public IdeasMapWidget GetMapWidgetContent(string contentGuid)
        {
            return _repository.GetContentItem<IdeasMapWidget>(contentGuid);
        }
    public IdeasMapWidgetText GetMapWidgetTextContent(string contentGuid)
    {
      return _repository.GetContentItem<IdeasMapWidgetText>(contentGuid);
    }
    

        public IdeasSelectedLinks GetSelectedLinksContent(string contentGuid)
        {
            return _repository.GetContentItem<IdeasSelectedLinks> (contentGuid);
        }
    public Models.IdeasHero GetIdeasHeroContent(string contentGuid)
    {
      return _repository.GetContentItem<Models.IdeasHero>(contentGuid);
    }
    public Models.IdeasPatientTitleTilesButton GetIdeasPatientTilesContent(string contentGuid)
    {
      return _repository.GetContentItem<Models.IdeasPatientTitleTilesButton>(contentGuid);
    }
    public IdeasTextImageSection GetTextImageContent(string contentGuid)
    {
      return _repository.GetContentItem<IdeasTextImageSection>(contentGuid);
    }
    public IdeasPatientTitle2Column IdeasPatientTitleTwoColumn(string contentGuid)
    {
      return _repository.GetContentItem<IdeasPatientTitle2Column>(contentGuid);
    }
    public IdeasPatientTwoImagesColumn IdeasPatientTwoImagesColumn(string contentGuid)
    {
      return _repository.GetContentItem<IdeasPatientTwoImagesColumn>(contentGuid);
    }

  }
}