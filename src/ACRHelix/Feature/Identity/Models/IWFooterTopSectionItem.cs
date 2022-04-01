using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Feature.Identity.Models;
using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Identity.Models
{
    
    public class IWFooterTopSectionItem : IIWFooterTopSectionItem
    {
        public virtual Guid Id { get; set; }

        public virtual Image Image { get; set; }
        public virtual Link Link { get; set; }

        public virtual int Index { get; set; }
    }
}