using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{    
    public interface IPledgeForm : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }

        [SitecoreField("Sub Title")]
        string SubTitle { get; set; }

        [SitecoreField("Button Text")]
        string ButtonText { get; set; }

        [SitecoreField("Pledge Form Type")]
        string PledgeType { get; set; }

        [SitecoreField("Send Form Data To")]
        string SendFormDataTo { get; set; }

        [SitecoreField("Confirmation Email From")]
        string ConfirmationEmailFrom { get; set; }

        [SitecoreField("Confirmation Email Subject")]
        string ConfirmationEmailSubject { get; set; }

        [SitecoreField("Confirmation Email Body")]
        string ConfirmationEmailBody { get; set; }

        [SitecoreField("Email Validation Error Message")]
        string ValidationErrorMessage { get; set; }



    }
}