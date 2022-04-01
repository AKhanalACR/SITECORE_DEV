using ACRHelix.Feature.Toolkits.Models;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.Toolkits.ViewModels
{
    public class ResourcesViewModel
    {
        public IEnumerable<Resource> Resources { get; set; }
    }
}