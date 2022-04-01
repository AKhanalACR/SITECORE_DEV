using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Personify.Models.Informz
{
  public class InformzCustomerData
  {
        public bool EmailExists { get; set; }
        public string CustomerID { get; set; }
        //public string SubCustomerID { get; set; }
        public string OptInCodes { get; set; }
        public bool IsMember { get; set; }
    }
}