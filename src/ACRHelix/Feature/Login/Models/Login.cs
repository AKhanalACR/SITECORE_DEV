using ACRHelix.Feature.Login.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using System.Reflection;

namespace ACRHelix.Feature.Login.Models
{
  public class Login : ILogin
  {
    public Login()
    {

    }

    public Login(Login other)
    {
      Type log = typeof(Login);
      PropertyInfo[] props = log.GetProperties();
      foreach (var p in props)
      {
        p.SetValue(this, p.GetValue(other));
      }
    }

    public virtual ID Id { get; set; }

    public virtual Link BecomeAMemberLink
    {
      get;set;
    }

    public virtual Link ForgotPasswordLink
    {
      get; set;
    }

    public virtual Link NeedHelpLink
    {
      get; set;
    }

    public virtual string RightSectionText
    {
      get; set;
    }

    public virtual string RightSectionTitle
    {
      get; set;
    }

    public virtual string SubTitle
    {
      get; set;
    }

    public virtual string Title
    {
      get; set;
    }

    public virtual string RightSectionBottomText
    {
      get;set;
    }


    public virtual Link AccreditationLoginLink
    {
      get;set;
    }

    public virtual string Questions
    {
      get;set;
    }

    public virtual string AccreditationTooltip
    {
      get;set;
    }

  }
}