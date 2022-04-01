using ACRHelix.Feature.ImageWiselyContent.Models;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.ViewModels
{
    public class RadiationSafetyViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public int ItemsToDisplay { get; set; }
        public string NewSectionTitle { get; set; }
        public string PreviousSectionTitle { get; set; }

        public IEnumerable<IContentPage> ModalitiesList { get; set; }

        public IEnumerable<IArticlePage> ArticlePagesList { get; set; }
    }
}