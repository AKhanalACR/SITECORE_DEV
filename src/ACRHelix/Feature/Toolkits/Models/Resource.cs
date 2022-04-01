using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ACRHelix.Feature.Toolkits.DAL;

namespace ACRHelix.Feature.Toolkits.Models
{
  public class Resource
  {
    [Key]
    [Column("Id")]
    public Int64 Id { get; set; }

    [Column("ToolName")]
    public string ToolName { get; set; }

    [Column("Description")]
    public string Description { get; set; }

    [Column("PostedDate")]
    public DateTime PostedDate { get; set; }

    [Column("ContentType")]
    public string ContentType { get; set; }

    [Column("ResourceType")]
    public string ResourceType { get; set; }

    [Column("Filename")]
    public string FileName { get; set; }

    [Column("Url")]
    public string Url { get; set; }

    public string Link
    {
      get
      {
        if (!string.IsNullOrWhiteSpace(FileName))
          return ReferenceItems.MediaFolderUrl + FileName;
        else
          return Url;
      }
      
    }

    [Column("Status")]
    public string Status { get; set; }

    //[Column("Reviewer")]
    //public string Reviewer { get; set; }
  }
}