using Sitecore.Data.Items;
using System.Linq;
using System.Web;
using System.Web.Services;
using Sitecore.Text;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System;
using Sitecore.Data;
using Sitecore.Links;

namespace ACR.Foundation.WebServices.Services
{
  /// <summary>
  /// Summary description for HeaderFooterService
  /// </summary>
  [WebService(Namespace = "http://qa.acr.org")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  // [System.Web.Script.Services.ScriptService]
  public class HeaderFooterService : System.Web.Services.WebService
  {
    [WebMethod]
    public string GetFooter()
    {
      try
      {
        string homePageId = "658E9C4C-194C-44C7-A9E5-EC30D7292235";

        var pageDocument = GetPageDocumentById(homePageId);
        var footer = pageDocument.DocumentNode
                                 .SelectNodes("//footer")
                                 .Last();
        footer = RewriteUrls(footer);
        return footer.OuterHtml;
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("Error getting footer webservice", ex, this);
      }
      return "error";
    }

    [WebMethod]
    public string GetHeader()
    {
      try
      {
        string homePageId = "658E9C4C-194C-44C7-A9E5-EC30D7292235";
        string searchResultsPageId = "{BEC4111C-6000-4A7D-9C30-2BCF4C4D23AB}";

        var pageDocument = GetPageDocumentById(homePageId);

        //Sitecore.Diagnostics.Log.Error("DOCUMENT=" + pageDocument.DocumentNode.OuterHtml, this);

        var header = pageDocument.DocumentNode
                                 .SelectNodes("//header")
                                 .First();
        header = RewriteHeaderNotAutenticated(header);

        header = RewriteHeaderSearchbox(header, searchResultsPageId);
        return header.OuterHtml;
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("Error getting header webservice", ex, this);
      }
      return "error";
    }    

    [WebMethod]
    public string GetHeaderAuthenticated(){
    try
    {
      string homePageId = "658E9C4C-194C-44C7-A9E5-EC30D7292235";

      var pageDocument = GetPageDocumentById(homePageId);
      var header = pageDocument.DocumentNode
                               .SelectNodes("//header")
                               .First();

      //TODO: modify based on logged in user
      header = RewriteHeaderAuthenticated(header);

      return header.OuterHtml;
    }
    catch (Exception ex)
    {
      Sitecore.Diagnostics.Log.Error("Error getting header webservice", ex, this);
    }
    return "error";
  }


    private HtmlDocument GetPageDocumentById(string id)
    {
      try
      {
        Item page = Sitecore.Data.Database.GetDatabase("web").GetItem(new Sitecore.Data.ID(id));
        if (page == null)
        {
          Sitecore.Diagnostics.Log.Error("Cannot get item from database", this);
        }
        var url = GetBaseUrl();
        url["sc_itemid"] = id;

        var web = new HtmlWeb();
        var doc = web.Load(url.ToString());

        return doc;
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("error getting html",ex, this);
        
      }
      return null;
    }

    private HtmlNode RewriteHeaderAuthenticated(HtmlNode node)
    {
      node = RewriteUrls(node);

      var loginli = node.SelectSingleNode("//li[@id='main-nav-login']");
      if (loginli != null)
      {
        var loginLink = loginli.Descendants("a").FirstOrDefault();
        if (loginLink != null) {
          loginLink.SetAttributeValue("href", "%%LOGOUTURL%%");
          loginLink.InnerHtml = "Log Out";
        }
      }

      var utilityNav = node.SelectSingleNode("//div[@id='utility-nav']");
      if (utilityNav != null)
      {
        var ul = utilityNav.Descendants("ul").FirstOrDefault();
        if (ul != null)
        {
          var li = ul.Descendants("li").FirstOrDefault();
          if (li != null)
          {
            li.ParentNode.InsertBefore(HtmlNode.CreateNode("<li><a class=\"logged-in-username\">Welcome, %%USERNAME%%</a></li>"), li);
          }
        }
      }

      return node;
    }

    private HtmlNode RewriteHeaderNotAutenticated(HtmlNode node)
    {
      node = RewriteUrls(node);

      var loginli = node.SelectSingleNode("//li[@id='main-nav-login']");
      if (loginli != null)
      {
        var loginLink = loginli.Descendants("a").FirstOrDefault();
        if (loginLink != null) {
          loginLink.SetAttributeValue("href", "%%LOGINURL%%");
        }
      }

      return node;
    }

    private HtmlNode RewriteHeaderSearchbox(HtmlNode node, string id)
    {
      var searchDiv = node.SelectSingleNode("//div[@id='header-search']").SelectNodes("//div[contains(@class, 'inline-ul wide-12')]").FirstOrDefault();
      if (searchDiv != null)
      {
        var link = searchDiv.Descendants("a").FirstOrDefault();
        searchDiv.RemoveAllChildren();
        searchDiv.AppendChild(link);

        Item item = Sitecore.Data.Database.GetDatabase("web").GetItem(new ID(id));
        var searchHtml = HtmlNode.CreateNode("<ul class=\"form-search\"><li><input id=\"header_tbSearch\" placeholder=\"Enter your search\" name=\"header$tbSearch\" class=\"header_tbSearch\" type=\"text\"></li><li><a data-url=\"Search-sults\" id=\"header_hlSearchLink\" class=\"form-header-search-submit-btn\"></a></li></ul>");
        if (item != null)
        {
          try
          {
            searchHtml.Descendants("a").FirstOrDefault().Attributes["data-url"].Value = LinkManager.GetItemUrl(item);
          }
          catch(Exception ex)
          {
            Sitecore.Diagnostics.Log.Error("Error header-footer webservice search page url ", ex, this);
          }
          
        }
        searchDiv.AppendChild(searchHtml);
      }
      return node;
    }

    private HtmlNode RewriteUrls(HtmlNode node)
    {
      //StringWriter writer = new StringWriter();
      string baseUrl = GetBaseUrl().ToString();

      foreach (var img in node.Descendants("img"))
      {
        img.Attributes["src"].Value = new Uri(new Uri(baseUrl), img.Attributes["src"].Value).AbsoluteUri;
      }

      foreach (var a in node.Descendants("a"))
      {
        if (a.Attributes["href"] != null)
        {
          a.Attributes["href"].Value = new Uri(new Uri(baseUrl), a.Attributes["href"].Value).AbsoluteUri;
        }
      }

      var utilityNav = node.SelectSingleNode("//div[@class='action-utility-nav inline-ul']");
      if (utilityNav != null)
      {
        var ul = utilityNav.Descendants("ul").FirstOrDefault();
        if (ul != null)
        {
          var shop = ul.Descendants("li").FirstOrDefault();
          if (shop != null)
          {
            var icon = shop.Descendants("i").FirstOrDefault();
            if (icon != null)
            {
              icon.ParentNode.InsertBefore(HtmlNode.CreateNode("<span class=\"cart-count\">(%%CARTCOUNT%%)</span>"),icon);

            }
            var link = shop.Descendants("a").FirstOrDefault();
            if (link != null)
            {
              link.SetAttributeValue("href", "%%CARTURL%%");
            }
          }


        }
      }

   
      return node;
    }

    private UrlString GetBaseUrl()
    {
      var url = new UrlString();
      try
      {
        url.HostName = HttpContext.Current.Request.Url.Host;
        url.Protocol = HttpContext.Current.Request.Url.Scheme;
        url.Path = "/";

      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("Error getting footer baseurl", ex, this);
      }
      return url;
    }
  }
}
