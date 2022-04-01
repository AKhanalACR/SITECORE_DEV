using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.IdeasResources.ViewModels
{
    public class IdeasSelectedResourcesViewModel
    {
        public IdeasSelectedResourcesViewModel()
        {
            SelectedResources = new List<Models.IdeasResource>();
        }
        public virtual ID Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Subtitle { get; set; }

        public virtual Link ViewMoreLink { get; set; }

        public virtual string ViewMoreLinkText { get; set; }
        public virtual List<Models.IdeasResource> SelectedResources { get; set; }
    }
}