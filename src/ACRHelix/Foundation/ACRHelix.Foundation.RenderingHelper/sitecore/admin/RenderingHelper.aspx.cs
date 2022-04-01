using ACR.Foundation.Personify.Importers;
using ACR.Foundation.Personify.MeetingSearch;
using HtmlAgilityPack;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Layouts;
using Sitecore.SecurityModel;
using Sitecore.Sites;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ACRHelix.Foundation.RenderingHelper.sitecore.admin
{
  public partial class RenderingHelper : System.Web.UI.Page
  {

    protected void Page_Load(object sender, EventArgs e)
    {
      //resultLbl.Text = "";
      if (!Sitecore.Context.User.IsAdministrator)
      {
        Response.StatusCode = 403;



      }
    }


    protected void testlink_Click(object sender, EventArgs e)
    {
      var itemIds = new string[] {
        "{F4A8BB26-B5CF-465F-B45D-83EDF5D599DE}",
        "{E18B08F7-B085-4F89-BE29-E120EBC28603}",
        "{7E849CBA-2E97-495A-B339-272537446D43}",
        "{6DB8C3A3-D262-41F2-92CF-B3814D948940}"
        ,"{7AA81F9F-F928-4CA1-A354-F169D0879F3A}"
      };

      using (new SiteContextSwitcher(SiteContext.GetSite("website")))
      {
        Sitecore.Links.UrlOptions options = Sitecore.Links.UrlOptions.DefaultOptions;
        options.Site = Sitecore.Configuration.Factory.GetSite("website");
        options.AlwaysIncludeServerUrl = false;


        List<string> links = new List<string>();

        foreach (var i in itemIds)
        {
          var item = Database.GetDatabase(RenderingMerger.Constants.MasterDB).GetItem(i);
          links.Add(FixLink(Sitecore.Links.LinkManager.GetItemUrl(item)));
        }

        MeetingSearchManager msm = new MeetingSearchManager(MeetingSearchManager.IndexEnum.Web);
        var meetings = msm.GetAllMeetings().Take(5).ToList();

        foreach (var m in meetings)
        {
          //links.Add(m.Url);

          var meetingItem = m.GetItem();
          if (meetingItem != null)
          {

            links.Add(Sitecore.Links.LinkManager.GetItemUrl(meetingItem, options));

          }
        }

        //linksLt.Text = string.Join("<br>", links);
      }

    }

    private string FixLink(string link)
    {
      string match = "/sitecore/shell";
      int index = link.IndexOf(match, StringComparison.OrdinalIgnoreCase);
      if (index == 0)
      {
        link = link.Substring(match.Length);
      }
      return link;
    }

    //protected void updateRenderings_Click(object sender, EventArgs e)
    //{
    //  bool parsed = false;
    //  string item = itemInput.Text.Trim();
    //  if (!string.IsNullOrWhiteSpace(item) && Sitecore.Context.User.IsAdministrator)
    //  {
    //    ID id = new ID();
    //    if (Sitecore.Data.ID.TryParse(item, out id))
    //    {
    //      parsed = true;
    //      var scItem = Database.GetDatabase(RenderingMerger.Constants.MasterDB).GetItem(id);
    //      var result = RenderingMerger.MergeRenderings(scItem, copyToTemplateCB.Checked);

    //      if (result.Key)
    //      {
    //        resultLbl.Text = "Shared Renderings updated succesfully!";
    //        resultLbl.ForeColor = System.Drawing.Color.Green;
    //      }
    //      else
    //      {
    //        resultLbl.Text = "Error updating shared renderings! Error: " + result.Value;
    //      }
    //    }
    //    if (!parsed)
    //    {
    //      resultLbl.Text = "Error parsing SitecoreID";
    //    }
    //  }
    //}

    protected void deleteLocalContent_Click(object sender, EventArgs e)
    {
      var localContent = Database.GetDatabase(RenderingMerger.Constants.MasterDB).SelectItems("fast:/sitecore/content//*[@@templateid='{08C1C3FE-99F2-40E8-B4CF-535724D4F1AF}']");

      List<ID> affectedItems = new List<Sitecore.Data.ID>();
      List<Item> itemsToDelete = new List<Item>();

      List<string> affectedURLs = new List<string>();

      foreach (var local in localContent)
      {
        var layoutItem = local.Parent;

        var finalLayoutField = new LayoutField(layoutItem.Fields[Sitecore.FieldIDs.FinalLayoutField]);

        if (finalLayoutField != null)
        {
          var finalLayoutDefinition = LayoutDefinition.Parse(finalLayoutField.Value);
          string xml = finalLayoutDefinition.ToXml().ToLower();

          foreach (Item child in local.GetChildren())
          {
            string id = child.ID.ToString();

            string dsid = string.Format("ds=\"{0}\"", id).ToLower();

            if (!xml.Contains(dsid))
            {
              itemsToDelete.Add(child);
              if (!affectedItems.Contains(layoutItem.ID))
              {
                affectedItems.Add(layoutItem.ID);
                affectedURLs.Add(layoutItem.GetCanonicalUrl());
              }
            }
          }
        }
      }
      using (new SecurityDisabler())
      {
        foreach (var item in itemsToDelete)
        {
          item.RecycleChildren();
          item.Recycle();
        }
      }
      StringBuilder sb = new StringBuilder();
      int i = 0;
      foreach (var url in affectedURLs)
      {
        sb.AppendLine(string.Format("<a target=\"_blank\" href=\"{0}\">{0}-{1}</a><br>", url, affectedItems[i].ToString()));
        i++;
      }
      //deletedItems.Text = sb.ToString();
    }

    protected void syncTemplateDataMedia_Click(object sender, EventArgs e)
    {

      var master = Database.GetDatabase(RenderingMerger.Constants.MasterDB);
      var itemsToSync = master.SelectItems("/sitecore/media library//*");
      foreach (var item in itemsToSync)
      {
        if (item.IsDerived("{D7890554-C645-41C4-810B-0DB540324EF1}"))
        {
          item.Editing.BeginEdit();
          item.Fields["{E74D0264-754C-47BF-AD94-D3DFAAA9314E}"].Value = item.Fields["{9B252240-EAE1-4951-9047-0CFBA8B8BF03}"].Value; //tile text
          item.Fields["{5D987E92-09F0-4A11-AF3A-F3F4B11EB50D}"].Value = item.Fields["{93A3C0F1-3F92-4C30-B7FA-AEB03465D45B}"].Value;
          item.Fields["{2BF6BD9C-EE0C-4B72-A03E-FD29C32518A6}"].Value = item.Fields["{32C69800-70C9-48B7-9BA3-3269C86625B8}"].Value;
          item.Editing.EndEdit();
        }
      }
    }

    protected void syncTemplateData_Click(object sender, EventArgs e)
    {
      var master = Database.GetDatabase(RenderingMerger.Constants.MasterDB);
      var homePage = master.GetItem("{46B9DC2B-7F03-4092-958C-77D051C30142}");

      var itemsToSync = master.SelectItems("/sitecore/content//*[@@templateid!='{62BEEA1D-6B79-4E0C-A98F-E337E321DBBE}']");
      var branchItems = master.SelectItems("/sitecore/templates/Branches//*");

      foreach (var item in itemsToSync)
      {
        if (item.IsDerived("{D7890554-C645-41C4-810B-0DB540324EF1}"))
        {
          item.Editing.BeginEdit();
          item.Fields["{E74D0264-754C-47BF-AD94-D3DFAAA9314E}"].Value = item.Fields["{9BB32976-D1D3-4F09-8C50-21C6E68D364C}"].Value; //tile text
          item.Fields["{2BF6BD9C-EE0C-4B72-A03E-FD29C32518A6}"].Value = item.Fields["{C04EBFFE-6F55-4403-AD37-E46A5D63B678}"].Value;
          item.Fields["{5D987E92-09F0-4A11-AF3A-F3F4B11EB50D}"].Value = item.Fields["{05FE47AB-3FEA-485F-A128-08234B800B3C}"].Value;
          item.Editing.EndEdit();
        }
      }

      foreach (var item in branchItems)
      {
        if (item.IsDerived("{D7890554-C645-41C4-810B-0DB540324EF1}"))
        {
          item.Editing.BeginEdit();
          item.Fields["{E74D0264-754C-47BF-AD94-D3DFAAA9314E}"].Value = item.Fields["{9BB32976-D1D3-4F09-8C50-21C6E68D364C}"].Value; //tile text
          item.Fields["{2BF6BD9C-EE0C-4B72-A03E-FD29C32518A6}"].Value = item.Fields["{C04EBFFE-6F55-4403-AD37-E46A5D63B678}"].Value;
          item.Fields["{5D987E92-09F0-4A11-AF3A-F3F4B11EB50D}"].Value = item.Fields["{05FE47AB-3FEA-485F-A128-08234B800B3C}"].Value;
          item.Editing.EndEdit();
        }
      }
    }

    protected void fixd_Click(object sender, EventArgs e)
    {
      using (new SecurityDisabler())
      {
        DateTime archiveDate = new DateTime(2017, 11, 22, 14, 0, 0);
        //string pathPrefix = "/sitecore/content/ACR/CME and Learning Activities";

        // get the recyclebin for the master database
        Sitecore.Data.Archiving.Archive archive = Sitecore.Data.Database.GetDatabase("master").Archives["recyclebin"];

        // get as many deleted items as possible 
        // where the archived date is after a given date 
        // and the item path starts with a given path
        var itemsRemovedAfterSomeDate =
            archive.GetEntries(0, int.MaxValue)
                    .Where(entry =>
                        entry.ArchiveDate > archiveDate //&& entry.OriginalLocation.StartsWith(pathPrefix)
                    ).ToList();
        List<string> restored = new List<string>();
        foreach (var itemRemoved in itemsRemovedAfterSomeDate)
        {
          // restore the item
          archive.RestoreItem(itemRemoved.ArchivalId);

          restored.Add(itemRemoved.OriginalLocation + " - " + itemRemoved.Name + " - " + itemRemoved.ItemId);

        }
        //resultsRestore.Text = string.Join("<br>", restored);
      }
    }

    protected void GetPersonifyComittees_Click(object sender, EventArgs e)
    {

      ACR.Foundation.Personify.PersonifyService.PersonifyEntitiesACR svc = new ACR.Foundation.Personify.PersonifyService.PersonifyEntitiesACR();

      var list = svc.GetCommitteeList();

      foreach (var commitee in list)
      {

        var members = svc.GetCommiteeMembers(commitee.MASTER_CUSTOMER_ID);


      }


    }

    protected void ChapterDataText_Click(object sender, EventArgs e)
    {
      ACR.Foundation.Personify.PersonifyService.PersonifyEntitiesACR svc = new ACR.Foundation.Personify.PersonifyService.PersonifyEntitiesACR();

      var list = svc.GetChapterList();

      //svc.GetCommitteePositions();

      List<string> positions = new List<string>();

      foreach (var commitee in list)
      {

        var members = svc.GetChapterMembers(commitee.ChapterID);

        foreach (var m in members)
        {
          if (!positions.Contains(m.Position))
          {
            positions.Add(m.Position);
          }
        }

      }
      positions.Sort();
      //positionsLbl.Text = string.Join("<br>", positions);
    }

    protected void updateChapterRenderings_Click(object sender, EventArgs e)
    {

      var chapters = Database.GetDatabase(RenderingMerger.Constants.MasterDB).SelectItems("/sitecore/content/ACR/Member Resources/Chapters//*[@@templateid='{185E7629-5035-4764-8439-ABC39402C4DC}']");
      foreach (var chapter in chapters)
      {
        var finalLayoutField = new LayoutField(chapter.Fields[Sitecore.FieldIDs.FinalLayoutField]);

        XDocument xdoc = XDocument.Parse(finalLayoutField.Value);


        var renderings = xdoc.Descendants().Where(x => x.Name.LocalName == "r").ToList();

        bool firstMatch = true;
        foreach (var rendering in renderings)
        {
          if (rendering.Attribute("s:id").Value == "{74DDCE15-F302-4E27-9146-46108B681FBA}")
          {
            if (firstMatch)
            {
              firstMatch = false;
              rendering.Attribute("s:id").Value = "";
            }
          }
        }



      }

    }

    protected void fixDSI_Click(object sender, EventArgs e)
    {
      var db = Database.GetDatabase(RenderingMerger.Constants.MasterDB);
      var items = db.SelectItems("/sitecore/content/DSI//*");

      foreach (var item in items)
      {
        var layoutField = item.Fields[Sitecore.FieldIDs.LayoutField];
        var finalLayout = item.Fields[Sitecore.FieldIDs.FinalLayoutField];

        using (new SecurityDisabler())
        {
          item.Editing.BeginEdit();
          if (layoutField.Value.Contains("ph=\"/content\""))
          {
            item[Sitecore.FieldIDs.LayoutField] = layoutField.Value.Replace("ph=\"/content\"", "ph=\"/dsi-content\"");
          }

          if (finalLayout.Value.Contains("ph=\"/content\""))
          {
            item[Sitecore.FieldIDs.FinalLayoutField] = finalLayout.Value.Replace("ph=\"/content\"", "ph=\"/dsi-content\"");
          }
          item.Editing.EndEdit();

        }

      }


    }


    private const string LogMessage = "Updated ItemID {0}, at {1}.  Updated {2} iframes.<br/>";

    protected void fixYoutubeIframes_Click(object sender, EventArgs e)
    {
      StringBuilder logViewer = new StringBuilder();

      var db = Database.GetDatabase(RenderingMerger.Constants.MasterDB);

      string connection = ConfigurationManager.ConnectionStrings[db.ConnectionStringName].ConnectionString;

      //int i = 0;
      int updated = 0;
      using (SqlConnection sqlconnection = new SqlConnection(connection))
      {
        SqlCommand command = new SqlCommand("SELECT * FROM [ACRHelix_master].[dbo].[VersionedFields] where Value like '%iframe%' and value like '%youtube%'", sqlconnection);

        //command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
        sqlconnection.Open();
        SqlDataReader reader = command.ExecuteReader();
        try
        {
          while (reader.Read())
          {
            string itemId = reader["ItemId"].ToString();
            string FieldId = reader["FieldId"].ToString();
            string value = reader["Value"].ToString();

            Item item = db.GetItem(itemId);

            string fullPath = item.Paths.FullPath;
            if (fullPath.StartsWith("/sitecore/content/ACR"))
            {

              try
              {
                var html = new HtmlDocument();
                html.LoadHtml(value);

                var iframes = html.DocumentNode.SelectNodes("//iframe").ToList();

                foreach (var iframe in iframes)
                {
                  updated = 0;
                  string src = iframe.Attributes["src"].Value;
                  if (src.ToLower().Contains("youtube"))
                  {
                    iframe.Attributes["src"].Remove();

                    iframe.Attributes.Add("data-src", src);
                    iframe.Attributes.Add("data-cookieconsent", "marketing");

                    HtmlNode message = HtmlNode.CreateNode("<div class=\"cookieconsent-optout-marketing cookiebot-video\">Please <a href=\"javascript:Cookiebot.renew()\">accept marketing cookies </a> to watch this video.</div>");

                    iframe.ParentNode.InsertAfter(message, iframe);

                    updated++;
                  }

                }
                using (StringWriter sw = new StringWriter())
                {

                  html.Save(sw);
                  logViewer.AppendFormat(LogMessage, itemId, fullPath, updated);

                  item.Editing.BeginEdit();
                  try
                  {
                    item[FieldId] = sw.ToString();
                    item.Editing.EndEdit();

                    Publisher.SmartPublishItems(Sitecore.Data.ID.Parse(itemId));

                  }
                  catch (Exception ex)
                  {
                    logViewer.AppendLine("error updating itemid " + itemId + " " + ex.Message + "-" + ex.StackTrace + "<br/>");
                    item.Editing.CancelEdit();
                  }
                }

              }
              catch (Exception ex)
              {
                logViewer.AppendLine("Error updating item " + itemId + " Error: " + ex.Message + "-" + ex.StackTrace + "<br/>");
              }

            }


          }
        }
        finally
        {
          // Always call Close when done reading.
          reader.Close();
          youtube_Output.Text = logViewer.ToString();
        }
      }



    }


    /*
protected void addSearchRendering_Click(object sender, EventArgs e)
{
var master = Database.GetDatabase(RenderingMerger.Constants.MasterDB);

List<string> modifiedPaths = new List<string>();

RenderingDefinition searchBox = new RenderingDefinition();
searchBox.ItemID = "{B2435B03-C62A-44DE-8790-A1584166FEA3}";
searchBox.Placeholder = "search";


var templates = master.SelectItems("/sitecore/content/ACR//*[(@__Final Renderings!='' or @__Renderings!='') and @@templateid!='{62BEEA1D-6B79-4E0C-A98F-E337E321DBBE}']");
foreach (var t in templates)
{
//if ((t.Paths.FullPath.Contains("System") || t.Paths.FullPath.Contains("Coveo") || t.Paths.FullPath.Contains("Sample")) == false)
//{
var layoutField = new LayoutField(t.Fields[Sitecore.FieldIDs.LayoutField]);
var finallayoutField = new LayoutField(t.Fields[Sitecore.FieldIDs.FinalLayoutField]);
if (finallayoutField != null)
{
var finalLayoutDefinition = LayoutDefinition.Parse(finallayoutField.Value);
var layoutDefinition = LayoutDefinition.Parse(layoutField.Value);

if (!finalLayoutDefinition.ToXml().Contains("{B2435B03-C62A-44DE-8790-A1584166FEA3}"))
{
DeviceDefinition deviceDefinition = layoutDefinition.GetDevice("{FE5D7FDF-89C0-4D99-9AA3-B5FBD009C9F3}");//default device
deviceDefinition.AddRendering(searchBox);

t.Editing.BeginEdit();
t.Fields[Sitecore.FieldIDs.LayoutField].Value = layoutDefinition.ToXml();
t.Editing.EndEdit();

modifiedPaths.Add(t.Paths.FullPath);
}


modifiedPaths.Add(t.Paths.FullPath);
var finalLayoutDefinition = LayoutDefinition.Parse(finallayoutField.Value);
using (new EditContext(t))
{
layoutField.Value = finalLayoutDefinition.ToXml();
t.Fields[Sitecore.FieldIDs.FinalLayoutField].Reset();
t.Editing.AcceptChanges();
}

//}
}
//var finalLayoutField = new LayoutField(

modifiedRenderings.Text = string.Join("<br>", modifiedPaths);
}
}*/
  }

}