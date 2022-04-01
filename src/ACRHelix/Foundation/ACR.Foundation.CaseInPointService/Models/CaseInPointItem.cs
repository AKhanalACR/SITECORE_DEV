using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.CaseInPointService.Models
{
    public class CaseInPointItem
    {
        public string CaseId { get; set; }
        public string History { get; set; }
        public DateTime? PublishDate { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
    }
}