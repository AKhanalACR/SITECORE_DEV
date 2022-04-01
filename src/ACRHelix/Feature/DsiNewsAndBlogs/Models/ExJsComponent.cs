using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
    public class ExJsComponent : IExJsComponent
    {
        public Guid Id { get; }
        public string Title { get; }
        public string RichText { get; set; }
        public Link ModuleUrl { get; set; }
        public string ContainerClass { get; set; }
    }
}