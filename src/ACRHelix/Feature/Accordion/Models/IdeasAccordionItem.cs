using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.Accordion.Models
{
    [SitecoreType(TemplateId = "{BCA13DC7-1B9B-4513-924F-F25E9689C5FB}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.TemplateAndBase)]

    public class IdeasAccordionItem : ICMSEntity
    {
        public virtual ID Id
        {
            get; set;
        }

        public virtual string Text
        {
            get; set;
        }

        public virtual string Title
        {
            get; set;
        }

        [SitecoreField("Table Text")]
        public virtual string TableText
        {
            get; set;
        }

        [SitecoreField("Category")]
        public virtual DictionaryEntry Category
        {
            get; set;
        }
    }
}