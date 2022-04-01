
using System;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using System.Collections.Generic;

namespace ACRHelix.Feature.RadPACContent.ViewModels
{
    public class HighlightsViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string RightTileText { get; set; }
        public string RightTileHeading { get; set; }
        public string LeftTileHeading { get; set; }
        public string LeftTileText { get; set; }      
        public Image RightTileImage { get; set; }
        public Image LeftTileImage { get; set; }
        public Link RightTileLink { get; set; }
        public Link LeftTileLink { get; set; }
        public string AdditionalTextSectionHeading { get; set; }
        public string AdditionalText { get; set; }

        public string [] Contributors
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(AdditionalText))
                    return AdditionalText.Split(new[] { "\r\n", "\r" }, StringSplitOptions.None);
                else
                    return new string[] { };
            }
        }
    }
}