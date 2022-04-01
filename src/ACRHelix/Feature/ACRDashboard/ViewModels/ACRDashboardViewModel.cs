using ACR.Foundation.SSO.Users;
using ACRHelix.Feature.ACRDashboard.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ACRDashboard.ViewModels
{
  public class ACRDashboardViewModel
  {
    public Models.ACRDashboard DashboardModel {get;set;}

    public List<BookmarkViewModel> MyBookmarks { get; set; }

    public List<BookmarkViewModel> ReccomendedArticles { get; set; }

    public int MessageCount { get; set; }

    public string MessageText
    {
      get
      {
        if (MessageCount == 1)
        {
          return "You have 1 unread message!";
        }
        else
        {
          return "You have " + MessageCount + " unread messages!";
        }
      }
    }

    public string FullName { get; set; }

    public IAcrUser User { get; set; }

    public Dictionary<string, List<string>> ChapterComissionsCommittees { get; set; } = null;

    public string RenewOrJoinText { get; set; }

    public string RenewOrJoinLink { get; set; }

    public bool DisplayCME { get; set; }

 
    public double CMECredits { get; set; }

    public int CMEPercentage
    {
      get
      {
        return Convert.ToInt32((CMECredits / 75) * 100);
      }
    }


    public string MemberSinceDate
    {
      get
      {
        if (User != null)
        {
          if (User.Profile != null)
          {
            return User.Profile.MemberSince.ToShortDateString();
          }
        }
        return null;
      }
    }

    public string Membership
    {
      get
      {
        if (User != null)
        {

          var member = User.GetRawCustomerInfo();
          if (member != null)
          {
            return member.Datacolumn1;
          }

        }
        return "";
      }
    }

    public string Address { get; set; }

  }
}