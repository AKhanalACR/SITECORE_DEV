using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRHelix.Feature.MembershipTestimonials.Models
{
    public interface IMediaItem : ICMSEntity
    {
        [SitecoreField("Mime Type")]

        string MimeType { get; set; }

        [SitecoreField("__Icon")]

        string Icon { get; set; }

        Guid Id { get; set; }

        string Name { get; set; }

        Stream Blob { get; set; }

        string Extension { get; set; }

        int Width { get; set; }
        int Height { get; set; }
    }
}
