using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.RadPAC.Models
{
    public class Signup : ISignup
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Richtext { get; set; }
        public string ButtonText { get; set; }
    }
}