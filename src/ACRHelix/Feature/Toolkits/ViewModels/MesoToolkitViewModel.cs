using ACRHelix.Feature.Toolkits.Models;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.Toolkits.ViewModels
{
  public class MesoToolkitViewModel
  {
    public Guid Id { get; set; }
    public string Title { get; set; }

    public Image Image { get; set; }

    public string FeedbackEmail { get; set; }

    public IEnumerable<FacetItem> Facets { get; set; }

    public IEnumerable<MesoResource> Resources { get; set; }

    public IEnumerable<SelectListItem> FacetTypes { get; set; }

    public int TotalCount { get; set; }

    public int PageNumber { get; set; }

    public int NbrOfPages { get { return (TotalCount + 9) / 10; } }

    public string ResultRange
    {
      get
      {
        if (TotalCount < 10)
          return 1 + "-" + TotalCount;

        if (PageNumber == 1)
          return PageNumber + "-" + (PageNumber * 10);
        else if(PageNumber > 1)
        {
          var upLimit = (PageNumber * 10) < TotalCount ? (PageNumber * 10) : TotalCount;
          return (((PageNumber - 1) * 10) + 1) + "-" + upLimit;
        }
         

        return 1 + "-" + 10;
      }
    }

    public string CustomerType { get; set; }
  }
}