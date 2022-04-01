using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.PersonifyCartService.Models
{
  [Serializable]
  public class AddCartResult
  {
    public bool Added { get; set; } = false;
    public string Result { get; set; }

    public string ProductId { get; set; }

    public string ProductName { get; set; }

    public int Quantity { get; set; }

    public string UnitPrice { get; set; }

    public string ProductImageUrl { get; set; }

    public string CartUrl { get; set; }

    
  }

  [Serializable]
  public class CartCountResult
  {
    public int CartCount { get; set; }
  }
}