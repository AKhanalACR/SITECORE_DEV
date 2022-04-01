using System.Collections.Generic;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;


namespace ACRHelix.Feature.Accordion.Models
{
    [SitecoreType(TemplateId = "{CD1379B5-E6DF-4108-AF71-FEBECC2B2E1E}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]

    public class IdeasSelectedAccordionItems : ICMSEntity
    {
        public virtual ID Id { get; set; }
        [SitecoreField("Title")]
        public virtual string Title { get; set; }

        [SitecoreField("Selected Accordions")]
        public virtual IEnumerable<IdeasAccordionItem> SelectedAccordions { get; set; }

        [SitecoreField("Selected Category")]
        public virtual DictionaryEntry SelectedCategory { get; set; }

        [SitecoreQuery("/sitecore/content/Ideas/Global/faqs/*[@@templateid = '{BCA13DC7-1B9B-4513-924F-F25E9689C5FB}']", IsRelative = false)]
        public virtual IEnumerable<IdeasAccordionItem> AllFAQs { get; set; }

    }
}