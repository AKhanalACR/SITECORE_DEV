
namespace ACRHelix.Feature.Accordion.Services
{
    public interface IContentService
    {
        Models.Accordion GetAccordionContent(string contentGuid);
        Models.IdeasSelectedAccordionItems GetIdeasSelectedAccordionContent(string contentGuid);

    }
}