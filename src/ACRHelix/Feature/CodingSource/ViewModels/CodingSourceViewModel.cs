using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.CodingSource.ViewModels
{
  public class CodingSourceViewModel
  {
    public ID Id { get; set; }
    public string Title { get; set; }

    public IEnumerable<Models.CodingSource> CodingSources { get; set; }


    public List<int> CodingSourceYears { get; set; }


  }
}