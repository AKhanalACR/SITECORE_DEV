using ACRHelix.Feature.ImageWiselyContent.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    public class TakeThePledge : ITakeThePledge
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
       
        public string DdlHeadText { get; set; }
    
        public IEnumerable<ILinkMenuItem> MenuItems { get; }
    }
}