using System.Collections.Generic;

namespace ACRHelix.Feature.Accordion.ViewModels
{
  public class AccordionViewModel
  {
    public AccordionViewModel()
    {
      AccordionItems = new List<Models.AccordionItem>();
    }

    public List<Models.AccordionItem> AccordionItems { get; set; }
  }
}