using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.RadPACContent.Models
{
    public class FAQItemList : IFAQItemList
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string AdditionalText { get; set; }

        public bool UnderlineSectionTitle { get; set; }
        public IEnumerable<IFAQItem> FAQItems { get; set; }

    }
}