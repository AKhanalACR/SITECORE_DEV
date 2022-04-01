using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.Navigation.ViewModels
{
    public class MenuItemViewModel
    {
        public ID Id { get; set; }
        public Link Link { get; set; }
        public string Title { get; set; }
        public string IconCSSClass { get; set; }
    }
}