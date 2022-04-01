using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using Sitecore.Data.Items;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{    
    public class PledgeForm : IPledgeForm 
    {        
        public ID Id { get; set; }
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string ButtonText { get; set; }

        public string PledgeType { get; set; }

        public string SendFormDataTo { get; set; }

        public string ConfirmationEmailFrom { get; set; }

        public string ConfirmationEmailSubject { get; set; }

        public string ConfirmationEmailBody { get; set; }

        public string ValidationErrorMessage { get; set; }

    }
}