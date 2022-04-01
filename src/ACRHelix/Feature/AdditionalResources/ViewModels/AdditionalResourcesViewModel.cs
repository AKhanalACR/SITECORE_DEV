using ACRHelix.Feature.AdditionalResources.Models;
using ACRHelix.Foundation.Dictionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.AdditionalResources.ViewModels
{
    public class AdditionalResourcesViewModel
    {
        public Sitecore.Data.ID Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public IEnumerable<AdditionalResourcesItem> Resources { get; set; }
    }
}