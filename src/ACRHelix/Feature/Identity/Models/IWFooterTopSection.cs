using ACRHelix.Feature.Identity.Models;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Identity.Models
{
    public class IWFooterTopSection : IIWFooterTopSection
    {
        public virtual Guid Id { get; set; }
        public virtual string SectionIntro { get; set; }

        public virtual IEnumerable<IWFooterTopSectionItem> SectionItems { get; }


    }
}