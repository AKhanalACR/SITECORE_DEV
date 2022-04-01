//using ACRHelix.Feature.Toolkits.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.RhecContent.DAL
{
  public class PledgeContext : DbContext
  {
    public PledgeContext() 
      : base("name=ACR_APP_DATA_Entities")
    {
    }

    //public DbSet<Resource> Resources { get; set; }

    //public DbSet<FacetItem> Facets { get; set; }

  }
}