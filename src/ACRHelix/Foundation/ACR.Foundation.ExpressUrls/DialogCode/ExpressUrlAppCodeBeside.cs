using ACR.Foundation.ExpressUrls.Data;
using Sitecore;
using Sitecore.Collections;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Sites;
using Sitecore.Web;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Pages;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
namespace ACR.Foundation.ExpressUrls
{
  [Serializable]
  internal class ExpressUrlAppCodeBeside : DialogForm
  {
    protected Listbox List;

    protected Edit NewExpressUrl;

    protected Edit NewQueryString;

    private string currentItemId;

    private string selectedSiteName;

    public ExpressUrlAppCodeBeside()
    {
    }

    protected void Add_Click()
    {
      using (ExpressUrlDatabase urlMappingDataContext = new ExpressUrlDatabase())
      {
        string value = this.NewExpressUrl.Value;
        string str = this.NewQueryString.Value;
        string str1 = StringUtil.EnsurePrefix('/', value);
        if (string.IsNullOrEmpty(value))
        {
          SheerResponse.Alert("Enter an Express URL to add to this item.", new string[0]);
        }
        else if (!IsValidExpressUrl(str1))
        {
          NameValueCollection nameValueCollection = new NameValueCollection();
          nameValueCollection["suggestedExpressUrl"] = GetFormattedUrl(str1, this.selectedSiteName);
          Context.ClientPage.Start(this, "ConfirmFormattedUrl", nameValueCollection);
        }
        else if (!IsNoConflict(str1, this.selectedSiteName))
        {
          NameValueCollection expressUrl = new NameValueCollection();
          expressUrl["conflictItemId"] = GetExpressUrl(str1, this.selectedSiteName).destSitecoreId;
          expressUrl["suggestedExpressUrl"] = str1;
          Context.ClientPage.Start(this, "ShowConflictingItems", expressUrl);
        }
        else if (string.IsNullOrEmpty(str) || IsValidQueryString(str))
        {
          UrlMap urlMap = InsertExpressUrl(this.currentItemId, str1, this.selectedSiteName, str);
          this.AddToList(urlMap);
          SheerResponse.SetOuterHtml("List", this.List);
          this.NewExpressUrl.Value =string.Empty;
          this.NewQueryString.Value =string.Empty;
        }
        else
        {
          SheerResponse.Alert("Query string must be a valid query string, or empty.", new string[0]);
        }
      }
    }

    protected void AddToList(UrlMap urlMap)
    {
      ListItem listItem = new ListItem()
      {
        ID = Sitecore.Web.UI.HtmlControls.Control.GetUniqueID("I")
      };
      listItem.Value = urlMap.urlMapId.ToString();
      if (string.IsNullOrEmpty(urlMap.queryString))
      {
        listItem.Header=urlMap.sourceUrl;
      }
      else
      {
        listItem.Header=string.Concat(urlMap.sourceUrl, " -> ?", urlMap.queryString);
      }
      this.List.Controls.Add(listItem);
    }

    protected void ConfirmFormattedUrl(ClientPipelineArgs args)
    {
      if (!args.IsPostBack)
      {
        string uri = UIUtil.GetUri("control:xmlExpressUrlConfirm");
        if (!string.IsNullOrEmpty(args.Parameters["suggestedExpressUrl"]))
        {
          uri = string.Concat(uri, "&suggestedExpressUrl=", args.Parameters["suggestedExpressUrl"]);
        }
        SheerResponse.ShowModalDialog(uri, true);
        args.WaitForPostBack();
      }
      else if (args.Result.Equals("yes"))
      {
       
          UrlMap urlMap = InsertExpressUrl(this.currentItemId, args.Parameters["suggestedExpressUrl"], this.selectedSiteName, this.NewQueryString.Value);
          this.AddToList(urlMap);
          SheerResponse.SetOuterHtml("List", this.List);
          this.NewExpressUrl.Value=string.Empty;
          this.NewQueryString.Value=string.Empty;
        
      }
    }

    protected void FillList(List<UrlMap> urls)
    {
      this.List.Controls.Clear();
      if (urls == null)
      {
        return;
      }
      foreach (UrlMap url in urls)
      {
        ListItem listItem = new ListItem()
        {
          ID = Sitecore.Web.UI.HtmlControls.Control.GetUniqueID("I")
        };
        listItem.Value = url.urlMapId.ToString();
        if (string.IsNullOrEmpty(url.queryString))
        {
          listItem.Header = url.sourceUrl;
        }
        else
        {
          listItem.Header = (string.Concat(url.sourceUrl, " -> ?", url.queryString));
        }
        this.List.Controls.Add(listItem);
      }
    }

    protected string GetCurrentContentGuid()
    {
      string queryString = WebUtil.GetQueryString("id");
      if (string.IsNullOrEmpty(queryString))
      {
        return string.Empty;
      }
      return queryString;
    }

    public static string GetSiteNameFromItem(string itemID)
    {
      string item = "master";
      string str = "web";
      string empty = string.Empty;
      Item item1 = Factory.GetDatabase(item).GetItem(new ID(itemID));
      if (item1 == null)
      {
        return empty;
      }
      foreach (Site site in SiteManager.GetSites())
      {
        SiteInfo siteInfo = new SiteInfo(site.Properties);
        if (siteInfo == null || siteInfo.Database != str || siteInfo.VirtualFolder != "/")
        {
          continue;
        }
        Item item2 = Factory.GetDatabase(item).GetItem(string.Concat(siteInfo.RootPath, siteInfo.StartItem));
        if (item2 == null || !item1.Axes.IsDescendantOf(item2))
        {
          continue;
        }
        empty = site.Name;
        break;
      }
      return empty;
    }

    private void LoadItemUrls(string itemGuid)
    {

        this.FillList(GetUrlMaps(itemGuid));
      
    }

    protected override void OnLoad(EventArgs args)
    {
      base.OnLoad(args);
      this.currentItemId = this.GetCurrentContentGuid();
      this.selectedSiteName = ExpressUrlAppCodeBeside.GetSiteNameFromItem(this.currentItemId);
      if (!Context.ClientPage.IsEvent)
      {
        this.LoadItemUrls(this.currentItemId);
      }
    }

    protected void Remove_Click()
    {
      if (this.List.Selected.Count<ListItem>() == 0)
      {
        SheerResponse.Alert("Enter an Express URL to add to this item.", new string[0]);
        return;
      }
    
        ListItem[] selected = this.List.Selected;
        for (int i = 0; i < (int)selected.Length; i++)
        {
          ListItem listItem = selected[i];
        DeleteExpressUrl(int.Parse(listItem.Value));
          this.RemoveFromList(this.List.SelectedItem);
        }
        this.LoadItemUrls(this.currentItemId);
        SheerResponse.SetOuterHtml("List", this.List);
      
    }

    protected void RemoveFromList(ListItem item)
    {
      this.List.Controls.Remove(item);
    }

    protected void ShowConflictingItems(ClientPipelineArgs args)
    {
      if (!args.IsPostBack)
      {
        string uri = UIUtil.GetUri("control:xmlExpressUrlConflict");
        if (!string.IsNullOrEmpty(args.Parameters["conflictItemId"]))
        {
          uri = string.Concat(uri, "&conflictItemId=", args.Parameters["conflictItemId"]);
        }
        SheerResponse.ShowModalDialog(uri, true);
        args.WaitForPostBack();
      }
      else if (args.Result.Equals("yes"))
      {
     
         DeleteExpressUrl(args.Parameters["conflictItemId"], args.Parameters["suggestedExpressUrl"], this.selectedSiteName);
          UrlMap urlMap = InsertExpressUrl(this.currentItemId, args.Parameters["suggestedExpressUrl"], this.selectedSiteName, this.NewQueryString.Value);
          this.AddToList(urlMap);
          SheerResponse.SetOuterHtml("List", this.List);
          this.NewExpressUrl.Value=(string.Empty);
          this.NewQueryString.Value=(string.Empty);
        
      }
    }


    public static string GetNoConflictName(string formattedUrl, int i, string siteName)
    {
      string noConflictName;
     
        if (!IsNoConflict(formattedUrl, siteName))
        {
          int num = i + 1;
          i = num;
          noConflictName = GetNoConflictName(formattedUrl, num, siteName);
        }
        else
        {
          noConflictName = (i <= 0 ? formattedUrl : string.Concat(formattedUrl, i));
        }
      
      return noConflictName;
    }

    public static bool IsNoConflict(string expressUrl, string siteName)
    {
      if (string.IsNullOrEmpty(expressUrl))
      {
        return false;
      }
      if (GetExpressUrl(expressUrl,siteName) != null)
      {
        return false;
      }
      return true;
    }

    public static bool IsValidExpressUrl(string expressUrl)
    {
      return RemoveSpecialCharacters(expressUrl).Equals(expressUrl.ToLower());
    }

    public static bool IsValidQueryString(string queryString)
    {
      NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(queryString);
      if (nameValueCollection.Count > 0)
      {
        if (!(
            from k in nameValueCollection.AllKeys
            select nameValueCollection[k]).Any<string>((string v) => string.IsNullOrEmpty(v)))
        {
          return !nameValueCollection.AllKeys.Any<string>((string k) => k == null);
        }
      }
      return false;
    }

    private static string RemoveSpecialCharacters(string expressUrl)
    {
      return expressUrl.ToLower();
    }

    private static string WildcardStringToRegex(string pattern)
    {
      return string.Concat("^", Regex.Escape(pattern).Replace("\\*", ".*"), "$");
    }

    public static string GetFormattedUrl(string expressUrl, string siteName)
    {
      string str = RemoveSpecialCharacters(expressUrl);
      if (!string.IsNullOrEmpty(str))
      {
        str = str.Replace("http://", string.Empty);
        int num = str.IndexOf("/");
        if (num == 0)
        {
          return GetNoConflictName(str, 0, siteName);
        }
        if (num > 0)
        {
          return GetNoConflictName(str.Substring(num), 0, siteName);
        }
        if (num < 0 && !string.IsNullOrEmpty(str))
        {
          return GetNoConflictName(string.Concat("/", str), 0, siteName);
        }
      }
      return string.Empty;
    }

    private static UrlMap GetExpressUrl(string url, string site)
    {
      using (var db = new ExpressUrlDatabase())
      {
        var urlmap = db.UrlMaps.FirstOrDefault(x => x.sourceUrl == url && (x.siteName == "" || x.siteName == site));
        return urlmap;
      }
    }

    private UrlMap InsertExpressUrl(string scid, string url, string sitename, string qs)
    {
      using (var db = new ExpressUrlDatabase())
      {
        var urlmap = db.UrlMaps.Add(new UrlMap()
        {
          destSitecoreId = scid,
         sourceUrl = url,
         siteName = sitename,
         queryString = qs
        });
        db.SaveChanges();
        return urlmap;
      }
      //return null;
    }

    private List<UrlMap> GetUrlMaps(string scid)
    {
      using (var db = new ExpressUrlDatabase())
      {
        return db.UrlMaps.Where(x => x.destSitecoreId == scid).ToList();
      }
    }

    private void DeleteExpressUrl(int id)
    {
      using (var db = new ExpressUrlDatabase())
      {
        var url = db.UrlMaps.FirstOrDefault(x => x.urlMapId == id);
        if (url != null)
        {
          db.UrlMaps.Remove(url);
          db.SaveChanges();
        }
      }
    }

    private void DeleteExpressUrl(string scid, string url, string site)
    {
      using (var db = new ExpressUrlDatabase())
      {
        var urlm = db.UrlMaps.FirstOrDefault(x => x.destSitecoreId == scid && x.sourceUrl == url && (x.siteName == site || x.siteName == ""));
        if (urlm != null)
        {
          db.UrlMaps.Remove(urlm);
          db.SaveChanges();
        }
      }
    }
  }
}