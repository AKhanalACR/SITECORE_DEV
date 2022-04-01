using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MembershipTestimonials.Models
{
    //Template - /sitecore/templates/System/Media/Unversioned/Image 
    [SitecoreType(AutoMap = true, TemplateId = "{F1828A2C-7E5D-4BBD-98CA-320474871548}")]
    public class MediaItem : IMediaItem
    {
        public virtual string MimeType { get; set; }
                
        public virtual string Icon { get; set; }

        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual Stream Blob { get; set; }

        public virtual string Extension { get; set; }

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
    }
}