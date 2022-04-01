using System.Collections.Generic;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.Accordion.ViewModels
{
    public class IdeasSelectedAccordionItemsViewModel
    {
        public IdeasSelectedAccordionItemsViewModel()
        {
            AccordionItems = new List<Models.IdeasAccordionItem>();
        }
        public virtual ID Id { get; set; }
        public string Title { get; set; }

        public List<Models.IdeasAccordionItem> AccordionItems { get; set; }
    }
}