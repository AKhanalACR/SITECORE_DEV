
using System;
using Sitecore.Data;
using System.Collections.Generic;
using ACRHelix.Feature.RadPACContent.Models;

namespace ACRHelix.Feature.RadPACContent.ViewModels
{
    public class FAQListViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string AdditionalText { get; set; }

        public bool UnderlineSectionTitle { get; set; }
        public IEnumerable<IFAQItem> FAQItems { get; set; }
    }
}