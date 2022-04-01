using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Personify.Models.Informz
{
  public class InformzCustomerExists
  {
    public List<string> Emails { get; set; } = new List<string>();
    public bool Exists { get; set; }

    public List<string> Name { get; set; } = new List<string>();
  }
}