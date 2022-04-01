using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRHelix.Feature.MembershipTestimonials.Models
{
    public interface IMediaFolder : ICMSEntity
    {
        Guid Id { get; set; }
    }
}
