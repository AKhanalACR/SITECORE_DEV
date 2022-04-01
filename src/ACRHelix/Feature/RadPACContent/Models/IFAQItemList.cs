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
    public interface IFAQItemList : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }

        string AdditionalText { get; set; }

        bool UnderlineSectionTitle { get; set; }
        IEnumerable<IFAQItem> FAQItems { get; set; }

    }
}