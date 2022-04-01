using ACRHelix.Feature.Identity.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Identity.Models
{
    public class CopyrightFooter : ICopyrightFooter
    {
        public Guid Id { get; set; }
        public string Copyright { get; set; }
        public Link Link { get; set; }
        public string AdditionalText { get; set; }       
    }
}