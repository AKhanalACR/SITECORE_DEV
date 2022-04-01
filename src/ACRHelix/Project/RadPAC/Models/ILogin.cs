using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Project.RadPAC.Models
{
    public interface ILogin : ICMSEntity
    {
        ID Id { get; set; }

        string Title { get; set; }

        string SubTitle { get; set; }

        Link NeedHelpLink { get; set; }

        Link ForgotPasswordLink { get; set; }

        string RichText { get; set; }

        Link CreateAccountLink { get; set; }

        string LoginErrorMessage { get; set; }

    }
}