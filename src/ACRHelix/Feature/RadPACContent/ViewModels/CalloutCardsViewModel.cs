
using System;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.RadPACContent.ViewModels
{
    public class CalloutCardsViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string LeftCardTitle { get; set; }
        public string LeftCardDescription { get; set; }
        public Link LeftCardLink { get; set; }

        public string RightCardTitle { get; set; }
        public string RightCardDescription { get; set; }
        public Link RightCardLink { get; set; }
    }
}