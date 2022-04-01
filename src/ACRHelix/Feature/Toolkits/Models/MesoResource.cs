using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ACRHelix.Feature.Toolkits.DAL;

namespace ACRHelix.Feature.Toolkits.Models
{
  public class MesoResource : Resource
  {
    [Column("CORE_KNOWLEDGE_SETTINGS")]
    public Int64 CoreKnowledge { get; set; }

    [Column("TARGET_GROUP_SETTINGS")]
    public string TargetGroup { get; set; }

    [Column("ANATOMY_SUBCATEGORY_SETTINGS")]
    public string AnatomySubcategory { get; set; }

    public new string Link
    {
      get
      {
        if (!string.IsNullOrWhiteSpace(FileName))
          return ReferenceItems.MesoMediaFolderUrl + FileName;
        else
          return Url;
      }

    }

    public string PdfLink { get; set; }

  }
}