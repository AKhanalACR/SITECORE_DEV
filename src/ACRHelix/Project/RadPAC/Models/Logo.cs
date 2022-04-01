using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.RadPAC.Models
{
    public class Logo : ILogo
    {
        public Guid Id { get; set; }
        public Link Link { get; set; }
        public Image Image { get; set; }
    }
}