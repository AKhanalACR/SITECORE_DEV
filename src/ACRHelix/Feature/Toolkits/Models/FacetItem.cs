using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACRHelix.Feature.Toolkits.Models
{
  public class FacetItem
  {
    [Column("TYPE")]
    public string Type { get; set; }

    [Column("Code")]
    public string Code { get; set; }

    [Column("Description")]
    public string Description { get; set; }
  }
}