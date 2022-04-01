using System;
using ACRHelix.Feature.Accordion.Models;
using ACRHelix.Foundation.Repository.Content;


namespace ACRHelix.Feature.Accordion.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public Models.Accordion GetAccordionContent(string contentGuid)
        {
            return _repository.GetContentItem<Models.Accordion>(contentGuid);
        }

        public Models.IdeasSelectedAccordionItems GetIdeasSelectedAccordionContent(string contentGuid)
        {
            return _repository.GetContentItem<Models.IdeasSelectedAccordionItems>(contentGuid);
        }
    }
}