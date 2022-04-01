using ACRHelix.Feature.Toolkits.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ACRHelix.Feature.Toolkits.Models
{
    public interface IPfccMediaItem : ICMSEntity
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Title { get; set; }
        string Keywords { get; set; }
        string Extension { get; set; }

        [SitecoreField("Mime Type")]
        string MimeType { get; set; }

        [SitecoreField("__Icon")]
        string Icon { get; set; }

        Stream Blob { get; set; }
  }
}