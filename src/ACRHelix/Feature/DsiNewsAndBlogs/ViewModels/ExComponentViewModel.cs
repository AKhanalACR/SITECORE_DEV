using ACRHelix.Feature.DsiNewsAndBlogs.Models;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.DsiNewsAndBlogs.ViewModels
{
    public class ExComponentViewModel
    {        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string RichText { get; set; }
        public Link ModuleUrl { get; set; }
        public string ContainerClass { get; set; }
    }
}