using ACRHelix.Feature.Login.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.Login.Models
{
  [SitecoreType(TemplateId = "{F212EE88-6B77-4EC0-8734-56C760B28DDA}", AutoMap = true, EnforceTemplate = SitecoreEnforceTemplate.Template)]
  public interface ILogin : ICMSEntity
  {
    ID Id { get; }

    string Title { get; set; }

    string SubTitle { get; set; }

    [SitecoreField("Need Help Link")]
    Link NeedHelpLink { get; set; }

    [SitecoreField("Forgot Password Link")]
    Link ForgotPasswordLink { get; set; }

    [SitecoreField("Right Section Title")]
    string RightSectionTitle { get; set; }

    [SitecoreField("Right Section Text")]
    string RightSectionText { get; set; }

    [SitecoreField("Right Section Bottom Text")]
    string RightSectionBottomText { get; set; }

    [SitecoreField("Become a Member Link")]
    Link BecomeAMemberLink { get; set; }

    [SitecoreField("Accreditation Login Link")]
    Link AccreditationLoginLink { get; set; }

    string Questions { get; set; }

    [SitecoreField("Accreditation Tooltip")]
    string AccreditationTooltip { get; set; }









  }
}