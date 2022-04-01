using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.RadPAC.Models
{
    public interface ICopyrightText : ICMSEntity
    {
        Guid Id { get; set; }

        string Copyright { get; set; }
        string Richtext { get; set; }
    }
}