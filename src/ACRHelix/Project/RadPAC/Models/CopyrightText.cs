using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.RadPAC.Models
{
    public class CopyrightText : ICopyrightText
    {
        public Guid Id { get; set; }
        public string Copyright { get; set; }
        public string Richtext { get; set; }
    }
}