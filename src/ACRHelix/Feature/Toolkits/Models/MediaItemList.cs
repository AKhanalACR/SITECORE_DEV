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
    public class MediaItemList : IMediaItemList
    {
      public Guid Id { get; set; }

      public IEnumerable<IPfccMediaItem> PdfMesoFiles { get; set; }
    }
}