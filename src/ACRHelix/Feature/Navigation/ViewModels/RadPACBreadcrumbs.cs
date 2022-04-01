using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.Navigation.ViewModels
{
    public class RadPACBreadcrumbsViewModel
    {
        public ID Id { get; set; }
        public List<Link> Links { get; set; }
    }
}