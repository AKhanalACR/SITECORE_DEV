using ACRHelix.Feature.ACRDashboard.Entity;
using ACRHelix.Feature.ACRDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ACRDashboard.ViewModels
{
  public class DashboardLinksViewModel
  {
    public IEnumerable<QuickLink> MyLinks { get; set; }
    public List<ViewModelQuickLink> AllLinks { get; set; }

    private const int _pageSize = 7;

    public bool Updated { get; set; } = false;

    public string LinkUrl { get; set; }

    public string LinkText { get; set; }


    public List<List<QuickLink>> PagedLinks
    {
      get
      {
        List<List<QuickLink>> listofList = new List<List<QuickLink>>();

        int added = 0;
        List<QuickLink> allEvents = MyLinks.ToList();
        while (added < MyLinks.Count())
        {
          List<QuickLink> elist = new List<QuickLink>();
          elist = allEvents.Skip(added).Take(_pageSize).ToList();
          listofList.Add(elist);
          added += elist.Count;
        }
        return listofList;
      }
    }


  }

  public class ViewModelQuickLink : QuickLink
  {
    public ViewModelQuickLink()
    {

    }
    public ViewModelQuickLink(DefaultQuickLink link, bool check)
    {
      this.LinkName = link.LinkText;
      this.LinkUrl = link.Link.Url;
      this.Checked = check;
    }
    public ViewModelQuickLink(QuickLink link, bool check)
    {
      this.LinkId = link.LinkId;
      this.LinkName = link.LinkName;
      this.LinkUrl = link.LinkUrl;
      this.PersonifyID = link.PersonifyID;
      this.Checked = check;
    }
    public bool Checked { get; set; }

    public QuickLink GetQuickLink()
    {
      return (QuickLink)this;
    }
  }
}