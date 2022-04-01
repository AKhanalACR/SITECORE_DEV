using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.RadPAC.Models
{
    public class LinkMenuItem : ILinkMenuItem
    {
        public Guid Id { get; set; }
        public  string Title { get; set; }
        public  Link Link { get; set; }        
        public  string IconCssClass { get; set; }
        
    }
}