using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.IdeasResources.ViewModels
{
    public class IdeasResourceListingsViewModel
    {
        public IdeasResourceListingsViewModel()
        {
            Resources = new List<Models.IdeasResource>();
        }
        public virtual ID Id { get; set; }
        public virtual string Title { get; set; }
        public virtual int NumberOfResources { get; set; }
        public virtual int NumberOfResourcesLoadMore { get; set; }
        public virtual List<Models.IdeasResource> Resources { get; set; }

    }
}