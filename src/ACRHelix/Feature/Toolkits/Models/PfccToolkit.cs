using ACRHelix.Feature.Toolkits.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Toolkits.Models
{
    public class PfccToolkit : IPfccToolkit
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public Image Image { get; set; }

        public Link ConfirmationPageUrl { get; set; }

        public Link ErrorPageUrl { get; set; }

        public string Email { get; set; }
        public string EmailFrom { get; set; }
        public string EmailSubject { get; set; }

        public string EmailBody { get; set; }
        public string Disclaimer { get; set; }
        public string DisclaimerCheckboxText { get; set; }
  }
}