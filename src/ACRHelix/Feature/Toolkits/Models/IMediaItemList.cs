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
    public interface IMediaItemList : ICMSEntity
    {
        Guid Id { get; set; }
        
        //[SitecoreQuery("./*[@@templateid = '{962B53C4-F93B-4DF9-9821-415C867B8903}']", IsRelative = true)]
        //IEnumerable<IPfccMediaItem> OtherMesoFiles { get; set; }

        [SitecoreQuery("./*[@@templateid = '{0603F166-35B8-469F-8123-E8D87BEDC171}']", IsRelative = true)]
        IEnumerable<IPfccMediaItem> PdfMesoFiles { get; set; }
  }
}