using ACRHelix.Feature.Tabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.Tabs.ViewModels
{
    public class RliTabsViewModel
    {
        public ID Id { get; set; }
        public IEnumerable<TabItem> Tabs { get; set; }
    }
    
}