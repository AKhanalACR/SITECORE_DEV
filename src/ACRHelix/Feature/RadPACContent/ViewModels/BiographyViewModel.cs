using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.RadPACContent.ViewModels
{
    public class BiographyViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }

        public string RichText { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string LinkedInUrl { get; set; }

        public Image Image { get; set; }
    }
}