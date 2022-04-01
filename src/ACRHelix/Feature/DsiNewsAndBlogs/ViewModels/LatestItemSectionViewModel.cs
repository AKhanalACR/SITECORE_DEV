using ACRHelix.Feature.DsiNewsAndBlogs.Models;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACRHelix.Feature.DsiNewsAndBlogs.Models;
using Sitecore.Data;

namespace ACRHelix.Feature.DsiNewsAndBlogs.ViewModels
{
    public class LatestItemSectionViewModel: ILatestItemSection
  {        
        public ID Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
    }
}