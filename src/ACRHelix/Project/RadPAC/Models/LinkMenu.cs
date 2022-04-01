using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.RadPAC.Models
{
    public class LinkMenu : ILinkMenu
    {
        public Guid Id { get; set; }

        public IEnumerable<ILinkMenuItem> MenuItems { get; set; }
    }
}