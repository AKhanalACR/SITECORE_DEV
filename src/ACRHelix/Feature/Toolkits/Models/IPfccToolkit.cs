using ACRHelix.Feature.Toolkits.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Toolkits.Models
{
    public interface IPfccToolkit : ICMSEntity
    {
        Guid Id { get; set; }
        string Title { get; set; }
        
        Image Image { get; set; }

        Link ConfirmationPageUrl { get; set; }

        Link ErrorPageUrl { get; set; }

        string Email { get; set; }
        string EmailFrom { get; set; }
        string EmailSubject { get; set; }

        string EmailBody { get; set; }
        string Disclaimer { get; set; }
        string DisclaimerCheckboxText { get; set; }
  }
}