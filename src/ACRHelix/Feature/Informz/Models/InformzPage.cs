using ACRHelix.Feature.Informz.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Informz.Models
{

  [SitecoreType(TemplateId = "{4132170E-7B44-4B39-8E83-22A8929A3BE8}", AutoMap = true, EnforceTemplate = SitecoreEnforceTemplate.Template)]
  public class InformzPage : ICMSEntity
  {
    public virtual ID Id { get; set; }
    public virtual string Title { get; set; }

    public virtual string SubTitle { get; set; }

        [SitecoreQuery(".//*[@@templateid='{8E9884F7-2E78-4F9F-A7CD-32CDC5538430}']",  IsRelative = true)]
        public virtual IEnumerable<InformzCategory> Categories { get; set; }

    [SitecoreField(FieldId = "{4BCB0B8D-82BD-4FFB-9785-3C665A9F2371}")]
    public virtual string RegisterTitle { get; set; }

    [SitecoreField(FieldId = "{A908533A-01CD-4376-85A9-A2DB0270E76E}")]
    public virtual string RegisterInstructions { get; set; }




        [SitecoreField("Registration Error Title")]
        public virtual string RegistrationErrorTitle { get; set; }

        [SitecoreField("Registration Error Message")]
        public virtual string RegistrationErrorMessage { get; set; }


        [SitecoreField("Update Profile Title")]
        public virtual string UpdateProfileTitle { get; set; }

        [SitecoreField("Email Try Again Message")]
        public virtual string EmailTryAgainMessage { get; set; }

        [SitecoreField("Contact MBR Message")]
        public virtual string ContactMBRMessage { get; set; }

    }
}