using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRHelix.Feature.MembershipTestimonials.Models
{
    [SitecoreType(AutoMap = true)]
    public interface ICategory : ICMSEntity
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
