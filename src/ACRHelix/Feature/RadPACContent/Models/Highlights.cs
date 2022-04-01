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
    public class Highlights : IHighlights
    {
        public ID Id { get; set; }
        public string Title { get; set; }

        public Image RightTileImage { get; set; }
        public string RightTileHeading { get; set; }
        public string RightTileText { get; set; }
        public Link RightTileLink { get; set; }

        public string LeftTileHeading { get; set; }
        public string LeftTileText { get; set; }       
        public Image LeftTileImage { get; set; }      
        public Link LeftTileLink { get; set; }

        public string AdditionalTextSectionHeading { get; set; }
        public string AdditionalText { get; set; }
    }
}