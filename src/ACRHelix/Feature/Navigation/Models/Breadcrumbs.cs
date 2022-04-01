using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.Navigation.Models
{
    public class Breadcrumbs : IBreadcrumbs
    {
        public ID Id { get; set; }
        public List<Link> Links { get; set; }
    }
}